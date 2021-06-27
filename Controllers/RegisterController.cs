using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HApi.Models;
using HApi.Storage.Entities;
using HApi.Crypto;
using LiteDB;
using HApi.DataAccess;
using HApi.Storage.InitialData;

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

            UserInit.Init(_db.Database, registerParameters);

            return new RegisterResult { Succeeded = true };
        }
    }
}
