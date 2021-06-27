using System;
using System.Collections.Generic;

namespace HApi.Crypto {
    public class Token {
        public Guid Guid { get; set; }
        public DateTime ExpireDateTime { get; set; }
    }

    public static class TokenStorage {
        private static object tokenLock = new object();
        private static object queueLock = new object();
        private static HashSet<Guid> ValidTokens = new HashSet<Guid>();
        private static Dictionary<Guid, LinkedListNode<Token>> AllTokens = new Dictionary<Guid, LinkedListNode<Token>>();
        private static LinkedList<Token> ExpireQueue = new LinkedList<Token>();

        public static void AddToken(Guid token, TimeSpan expiresIn){
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
                }
            }
        }

        public static bool CheckToken(Guid token)
        {
            lock (tokenLock)
            {
                if (!AllTokens.ContainsKey(token))
                    return false;

                // Remove all tokens that have expired
                var currentItem = AllTokens[token];
                Token currentToken = currentItem?.Value;

                var now = DateTime.UtcNow;

                if (currentToken.ExpireDateTime < now)
                {
                    lock (queueLock)
                    {
                        ValidTokens.Remove(currentToken.Guid);
                        AllTokens.Remove(currentToken.Guid);
                        ExpireQueue.Remove(currentToken);

                        return false;
                    }
                }
            }

            Update(); // Check other tokens in case any have expired...

            return true;
        }

        public static void Update(){
            lock(queueLock){
                // Remove all tokens that have expired
                var currentItem = ExpireQueue.First;
                Token currentToken = currentItem?.Value;
                
                var now = DateTime.UtcNow;

                while(currentToken != null && currentToken.ExpireDateTime < now){
                    lock (tokenLock)
                    {
                        ValidTokens.Remove(currentToken.Guid);
                        ExpireQueue.Remove(currentToken);
                    }

                    currentToken = ExpireQueue.First?.Value;
                }
            }
        }
    }
}