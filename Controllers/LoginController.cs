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
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IHDbContext _db;

        public LoginController(ILogger<LoginController> logger, IHDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpPost]
        public LoginResult Post([FromBody] LoginParameters loginParameters)
        {
            
            var users = _db.Database.GetCollection<User>();

            User user = users.Find(o => o.Username == loginParameters.Username).FirstOrDefault();

            if (user != null && user.Password_SHA256.Equals((new SHA256Hash(loginParameters.Password)).ToString()))
            {
                Guid newToken = Guid.NewGuid();
                TokenStorage.AddToken(newToken);
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
