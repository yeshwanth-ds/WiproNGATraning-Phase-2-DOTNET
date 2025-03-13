using BatchWebApi.Context;
using BatchWebApi.Models;
using BatchWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;


namespace BatchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        AppDbContext _context;
        IConfiguration _configuration;
        public  AuthenticationController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            IActionResult response = Unauthorized();
            var obj = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (obj != null)
            {
                var tokenString = GenerateJSONWebToken(obj);
                response = Ok(new { token = tokenString });
            }
            return response;

        }





        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // 🔹 Add Claims (including User ID)
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // ✅ Add User ID
        new Claim(JwtRegisteredClaimNames.Email, user.Email), // Optional: Add email
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique token ID
        new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"]),
        new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"]),
    };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims, // ✅ Attach claims
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }

}

