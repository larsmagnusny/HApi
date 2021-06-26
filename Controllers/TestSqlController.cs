using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HApi.Models;

namespace HApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestSqlController : ControllerBase
    {
        private readonly ILogger<TestSqlController> _logger;

        public TestSqlController(ILogger<TestSqlController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public LoginResult Get()
        {
            return new LoginResult{ Token = Guid.NewGuid().ToString() };
        }
    }
}
