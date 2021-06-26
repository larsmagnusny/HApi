using HApi.Crypto;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HApi.Storage.Entities {
    [Serializable]
    public class User : IEquatable<User>
    {
        public Guid UserId{ get; set; }
        public string Username{ get; set; }
        public SHA256Hash Password_SHA256 { get; set; }

        public Profile Profile { get; set; }

        public bool Equals([AllowNull] User other)
        {
            if (other == null)
                return false;

            return this.UserId == other.UserId;
        }
    }
}