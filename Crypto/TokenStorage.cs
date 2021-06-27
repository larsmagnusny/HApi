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
        private static LinkedList<Token> ExpireQueue = new LinkedList<Token>();

        public void AddToken(Guid token, TimeSpan expiresIn){
            var newToken = new Token {
                Guid = token,
                ExpireDateTime = DateTime.UtcNow.Add(expiresIn)
            };

            lock(tokenLock){
                if(!Tokens.ContainsKey(token))
                {
                    Tokens.Add(token);
                    ExpireQueue.AddLast(newToken);
                }
            }
        }

        public void Update(){
            lock(queueLock){
                // Remove all tokens that have expired
                var currentItem = ExpireQueue.First;
                Token currentToken = firstItem.Value;
                
                var now = DateTime.UtcNow;

                while(currentToken != null && currentToken.ExpireDateTime < now){
                    
                }
            }
        }
    }
}