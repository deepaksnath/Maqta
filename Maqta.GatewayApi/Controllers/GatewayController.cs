using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maqta.GatewayApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly IJwtAuthHelper _jwtAuthHelper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<GatewayController> _logger;

        public GatewayController(ILogger<GatewayController> logger, IJwtAuthHelper jwtAuthHelper, IConfiguration configuration)
        {
            _logger = logger;
            this._jwtAuthHelper = jwtAuthHelper;
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("Token")]        
        public IActionResult Post([FromBody] Account model)
        {
            var tokenExpiry = _configuration.GetValue<int>("Auth:TokenExpiry");
            var token = this._jwtAuthHelper.Authenticate(model.Username, model.Password, tokenExpiry);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            else
            {
                model.Password = null;
                model.Token = token;
                return Ok(model);
            }
        }

        [HttpGet]
        [Route("Test")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Success.");
        }
    }
}
