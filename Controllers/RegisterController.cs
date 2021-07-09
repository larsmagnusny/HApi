using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HApi.Models;
using LiteDB;
using HApi.DataAccess;
using HApi.DataAccess.Entities;
using HApi.DataAccess.InitialData;

namespace HApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly HContext _db;

        public RegisterController(ILogger<LoginController> logger, HContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpPost]
        public RegisterResult Post([FromBody] RegisterParameters registerParameters)
        {
            User existingUser = _db.Users.FirstOrDefault(u => u.Username == registerParameters.Username);
            Profile existingProfile = _db.Profiles.FirstOrDefault(p => p.Email == registerParameters.Email);

            if (existingUser != null || existingProfile != null)
                return new RegisterResult { Succeeded = false };

            UserInit.Init(_db, registerParameters);

            return new RegisterResult { Succeeded = true };
        }
    }
}
