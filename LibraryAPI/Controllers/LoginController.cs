using LibraryAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel loginModel)
        {
            IActionResult response = Unauthorized();
            var success = AuthenticateUser(loginModel);
            if ((bool)success)
            {
                var tokenString = GenerateJsonWebToken(loginModel);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private object GenerateJsonWebToken(UserModel loginModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private object AuthenticateUser(UserModel loginModel)
        {
            var result = _signInManager.PasswordSignInAsync
                (loginModel.Email, loginModel.Password, true, lockoutOnFailure: false).Result;
            return result.Succeeded;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Kwe()
        {
            return Ok("kwe");
        }
    }
}

