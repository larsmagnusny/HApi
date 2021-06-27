using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HApi.Models;
using HApi.Storage;
using HApi.Storage.Entities;
using HApi.Crypto;
using LiteDB;
using HApi.DataAccess;

namespace HApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IHDbContext _db;

        public RegisterController(ILogger<LoginController> logger, IHDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpPost]
        public RegisterResult Post([FromBody] RegisterParameters registerParameters)
        {
            var users = _db.Database.GetCollection<User>();
            var profiles = _db.Database.GetCollection<Profile>();

            User existingUser = users.Find(u => u.Username == registerParameters.Username).FirstOrDefault();
            Profile existingProfile = profiles.Find(p => p.Email == registerParameters.Email).FirstOrDefault();

            if (existingUser != null || existingProfile != null)
                return new RegisterResult { Succeeded = false };

            User user = new User
            {
                UserId = Guid.NewGuid(),
                Username = registerParameters.Username,
                Password_SHA256 = (new SHA256Hash(registerParameters.Password)).ToString()
            };

            Profile profile = new Profile
            {
                FirstName = registerParameters.FirstName,
                LastName = registerParameters.LastName,
                Email = registerParameters.Email
            };

            users.Insert(user);
            profiles.Insert(profile);

            return new RegisterResult { Succeeded = false };
        }
    }

    public class RegisterParameters
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
