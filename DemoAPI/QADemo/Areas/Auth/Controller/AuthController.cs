using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QADemo.Areas.Auth.Bo;
using QADemo.Areas.Auth.Service;

namespace QADemo.Areas.Auth.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelpers _jwtHelpers;
        private readonly AuthService _service;
        public AuthController(JwtHelpers jwtHelpers, AuthService service)
        {
            _jwtHelpers = jwtHelpers;
            _service = service;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginBo login)
        {
            string jwtToken = _jwtHelpers.GenerateToken(login.username);
            return Ok(jwtToken);
        }

        [Authorize]
        [HttpPost]
        public IActionResult GetUserName()
        { 
            Console.WriteLine("User="+User.Identity?.Name);
            return Ok("1111111");
        }

    }
}
