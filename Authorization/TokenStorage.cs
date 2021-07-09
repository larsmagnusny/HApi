using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace HApi.Authorization {
    public class Token {
        public Guid Guid { get; set; }
        public DateTime ExpireDateTime { get; set; }
    }

    public static class TokenStorage {
        public static void Init(IConfiguration configuration)
        {
            expiresIn = TimeSpan.FromMinutes((int)configuration.GetValue(typeof(int), "Timeout"));
            slidingExpiration = (bool)configuration.GetValue(typeof(bool), "SlidingExpiration");
        }

        private static object tokenLock = new object();
        private static object queueLock = new object();
        private static HashSet<Guid> ValidTokens = new HashSet<Guid>();
        private static Dictionary<Guid, LinkedListNode<Token>> AllTokens = new Dictionary<Guid, LinkedListNode<Token>>();
        private static LinkedList<Token> ExpireQueue = new LinkedList<Token>();

        private static Dictionary<Guid, Guid> TokenUsers = new Dictionary<Guid, Guid>();

        private static TimeSpan expiresIn = TimeSpan.FromMinutes(1);
        private static bool slidingExpiration = true;

        public static void AddToken(Guid token, Guid userId){
            Update(); // Check other tokens in case any have expired...

            var newToken = new Token {
                Guid = token,
                ExpireDateTime = DateTime.UtcNow.Add(expiresIn)
            };

            lock(tokenLock){
                if(!ValidTokens.Contains(token))
                {
                    ValidTokens.Add(token);
                    ExpireQueue.AddLast(newToken);
                    AllTokens.Add(token, ExpireQueue.Last);
                    TokenUsers.Add(token, userId);
                }
            }
        }

        public static bool CheckToken(Guid token)
        {
            Update(); // Check other tokens in case any have expired...

            lock (tokenLock)
            {
                if (!AllTokens.ContainsKey(token))
                    return false;

                // Remove all tokens that have expired
                var currentItem = AllTokens[token];
                Token currentToken = currentItem?.Value;

                var now = DateTime.UtcNow;

                lock (queueLock)
                {
                    if(currentToken.ExpireDateTime < now)
                    {
                        ExpireQueue.Remove(currentItem);
                        AllTokens.Remove(currentToken.Guid);
                        ValidTokens.Remove(currentToken.Guid);
                        TokenUsers.Remove(currentToken.Guid);
                        return false;
                    }

                    if (slidingExpiration)
                    {
                        currentToken.ExpireDateTime = DateTime.UtcNow.Add(expiresIn);

                        ExpireQueue.Remove(currentItem);
                        AllTokens.Remove(currentToken.Guid);
                        ExpireQueue.AddLast(currentToken);
                        AllTokens.Add(currentToken.Guid, ExpireQueue.Last);
                    }
                }
            }
            
            return true;
        }

        public static Guid? FindUser(Guid token)
        {
            lock (tokenLock)
            {
                if (TokenUsers.ContainsKey(token))
                    return TokenUsers[token];
            }

            return null;
        }

        public static void Update(){
            lock(queueLock){
                // Remove all tokens that have expired
                var currentItem = ExpireQueue.First;
                Token currentToken = currentItem?.Value;
                
                var now = DateTime.UtcNow;

                while(currentItem != null && currentToken != null && currentToken.ExpireDateTime < now){
                    lock (tokenLock)
                    {
                        ValidTokens.Remove(currentToken.Guid);
                        AllTokens.Remove(currentToken.Guid);
                        TokenUsers.Remove(currentToken.Guid);

                        if(currentItem.List != null)
                            ExpireQueue.Remove(currentItem);
                    }

                    currentItem = ExpireQueue.First;
                    currentToken = currentItem?.Value;
                }
            }
        }
    }
}