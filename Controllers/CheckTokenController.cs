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
    public class CheckTokenController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public CheckTokenController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool Post([FromBody] LoginParameters loginParameters)
        {
            return true;
        }
    }
}
