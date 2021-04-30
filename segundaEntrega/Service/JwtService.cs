using Entidad;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using segundaEntrega.Config;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using segundaEntrega.Models;

namespace segundaEntrega.Service
{
    public class JwtService
    {
        private readonly AppSetting _appSettings;
        public JwtService(IOptions<AppSetting> appSettings)=> _appSettings = appSettings.Value;
        public UsuarioViewModel GenerateToken(Usuario userLogIn)
        {
            // return null if user not found
            if (userLogIn == null) return null;
            var userResponse = new UsuarioViewModel() { FirstName = userLogIn.FirstName, LastName = userLogIn.LastName, User = userLogIn.User };
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userLogIn.User.ToString()),
                    new Claim(ClaimTypes.Email, userLogIn.Email.ToString()),
                    new Claim(ClaimTypes.Role, "Rol1"),
                    new Claim(ClaimTypes.Role, "Rol2"),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userResponse.Token = tokenHandler.WriteToken(token);
            return userResponse;
        }

    }
}