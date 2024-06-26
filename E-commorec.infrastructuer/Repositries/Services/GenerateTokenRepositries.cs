

using E_commorec.infrastructuer.Data;
using E_ommorec.core.Entity;
using E_ommorec.core.Services;
using E_ommorec.core.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_commorec.infrastructuer.Repositries.Services
{
    public class GenerateTokenRepositries : IGenerateTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUsers> manager;

        public GenerateTokenRepositries(IConfiguration configuration, AppDbContext context, UserManager<AppUsers> manager)
        {
            _configuration = configuration;
            _context = context;
            this.manager = manager;
        }

        public async Task<string> GetAndCreateToken(AppUsers user)
        {

            string[] roles = Roles.roles;
            string role = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                role = roles[i];
                bool result = await manager.IsInRoleAsync(user, role);
                if (result is true)
                {
                    break;
                }
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role,role ),

            };

            string secret = _configuration["Token:Secret"];
            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentNullException("Token secret is not configured");
            }

            byte[] key = Encoding.ASCII.GetBytes(secret);
            SigningCredentials credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(30), // Adjust token expiration time as needed
                Issuer = _configuration["Token:Issuer"],

                SigningCredentials = credentials,
                NotBefore = DateTime.UtcNow
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


    }
}

