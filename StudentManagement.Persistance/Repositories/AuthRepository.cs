using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagement.Persistance.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        #region Private Variables
        private readonly StudentManagementDbContext _studentDbContext;
        private readonly IConfiguration _config;
        #endregion
        #region Constructor
        public AuthRepository(StudentManagementDbContext studentDbContext, IConfiguration config)
        {
            _studentDbContext = studentDbContext;
            _config = config;
        }
        #endregion
        #region GET
        public string GenerateJwtToken(string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Role, role)
        };

            var token = new JwtSecurityToken(
                _config["JwtSettings:Issuer"],
                _config["JwtSettings:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}


