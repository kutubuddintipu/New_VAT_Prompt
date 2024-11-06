using BusinessLogicLayer.Select.Security;
using DataModelLayer;
using EntityLayer.AppDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VAT_Prompt_V2.Configuration;

namespace VAT_PromptAPI_V2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserLoginIndentityInfoBLL _userService;

        public LoginController(ApplicationDbContext context)
        {
            _userService = new UserLoginIndentityInfoBLL(context);
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var user = _userService.TryToLogin(loginRequest);
                if (user == null)
                {
                    return Unauthorized("Invalid credentials");
                }

                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {ex.Message}\n");

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("secure")]
        public IActionResult SecureEndpoint()
        {
            return Ok("This is a secure endpoint");
        }

        private string GenerateJwtToken(LoginRequest user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTConfig.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: JWTConfig.Issuer,
                audience: JWTConfig.Audience,
                claims: new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                },
                expires: DateTime.UtcNow.AddMinutes(JWTConfig.Timeout),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}