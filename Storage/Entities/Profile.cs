using System;
using System.Diagnostics.CodeAnalysis;

namespace HApi.Storage.Entities {
    [Serializable]
    public class Profile : IEquatable<User> {
        public Guid UserId{ get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Equals([AllowNull] User other)
        {
            if (other == null)
                return false;

            return this.UserId == other.UserId;
        }
    }
}