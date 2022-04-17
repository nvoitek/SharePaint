using Microsoft.IdentityModel.Tokens;
using SharePaint.Models;
using SharePaint.Repository.Interfaces;
using SharePaint.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SharePaint.Services
{
    // https://github.com/cornflourblue/aspnet-core-3-jwt-authentication-api/blob/master/Services/UserService.cs
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthorizationSettings _authorizationSettings;

        public UserService(IUserRepository userRepository, IAuthorizationSettings authorizationSettings)
        {
            _userRepository = userRepository;
            _authorizationSettings = authorizationSettings;
        }

        public async Task<User> Get(string id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<AuthorizationResult> Authorize(User user)
        {
            var users = await _userRepository.Get();
            var authUser = users.SingleOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            // return null if user not found
            if (authUser == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(authUser);

            return new AuthorizationResult { Token = token };
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authorizationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
