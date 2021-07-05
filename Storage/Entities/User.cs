using HApi.Crypto;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HApi.Storage.Entities {
    public class User
    {
        [Key]
        public Guid UserId{ get; set; }
        public string Username{ get; set; }
        public string Password_SHA256 { get; set; }
    }
}