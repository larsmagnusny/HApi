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
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IDataStorage<User> _userStorage;

        public LoginController(ILogger<LoginController> logger, IDataStorage<User> userStorage)
        {
            _logger = logger;
            _userStorage = userStorage;
        }

        [HttpPost]
        public LoginResult Post([FromBody] LoginParameters loginParameters)
        {
            User user = _userStorage.Find(o => o.Username == loginParameters.Username);

            if (user != null && user.Password_SHA256.Equals(new SHA256Hash(loginParameters.Password)))
            {
                Guid newToken = Guid.NewGuid();
                return new LoginResult { Token = newToken.ToString() };
            }

            return new LoginResult { Token = null };
        }
    }

    public class LoginParameters
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
