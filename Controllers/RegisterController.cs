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

namespace HApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IDataStorage<User> _userStorage;

        public RegisterController(ILogger<LoginController> logger, IDataStorage<User> userStorage)
        {
            _logger = logger;
            _userStorage = userStorage;
        }

        [HttpPost]
        public RegisterResult Post([FromBody] RegisterParameters registerParameters)
        {
            User existingUser = _userStorage.Find(u => u.Username == registerParameters.Username || u.Profile.Email == registerParameters.Email);

            if (existingUser != null)
                return new RegisterResult { Succeeded = false };

            User user = new User
            {
                UserId = Guid.NewGuid(),
                Username = registerParameters.Username,
                Password_SHA256 = new SHA256Hash(registerParameters.Password),
                Profile = new Profile
                {
                    FirstName = registerParameters.FirstName,
                    LastName = registerParameters.LastName,
                    Email = registerParameters.Email
                }
            };

            _userStorage.Add(user);
            _userStorage.SaveToDisk();

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
