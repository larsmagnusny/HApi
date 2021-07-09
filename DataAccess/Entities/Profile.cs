using System;
using System.ComponentModel.DataAnnotations;

namespace HApi.DataAccess.Entities {
    public class Profile {
        [Key]
        public Guid UserId{ get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}