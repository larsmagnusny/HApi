using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HApi.DataAccess.Entities {
    public class User
    {
        public User()
        {
            Computers = new HashSet<Computer>();
        }

        [Key]
        public Guid UserId{ get; set; }
        public string Username{ get; set; }
        public string Password_SHA256 { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}