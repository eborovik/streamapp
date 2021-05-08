using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Streamer.Database;
using Streamer.Helpers;
using Streamer.Interfaces;
using Streamer.Models;

namespace Streamer.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;
        private readonly Config _config;

        public UserService(DatabaseContext dbContext, Config config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public bool CheckUserExists(UserModel user)
        {
            var registeredUser = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            return  registeredUser != null;
        }

        public async Task CreateUser(UserModel user)
        {
            var newUser = new User
            {
                Email = user.Email,
                Name = user.Name,
                PasswordHash = PasswordHasher.Hash(user.Password)
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public string AuthenticateUser(UserModel user)
        {
            var registeredUser = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (registeredUser == null)
            {
                return null;
            }

            var passwordHash = PasswordHasher.Hash(user.Password);
            if (!PasswordHasher.Verify(user.Password, registeredUser.PasswordHash))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_config.JwtTokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
