using Lib.Modules.Auth.Domain.Dtos.Authenticated;
using Lib.Modules.Auth.Domain.Dtos.Login;
using Lib.Modules.Auth.Domain.Interfaces;
using Lib.Modules.Auth.Infrastructure.Helpers;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Application.Commands;

public abstract class Login
{   
    public class Command : IRequest<string>
    {
        public LoginRequestDto Dto { get; set; }
    }

    public class Handler :  IRequestHandler<Command, string>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            var email = command.Dto.Email;

            var currentUser = await _userRepository.GetAsync(
                filter: user => user.Email == email
                );

            if(currentUser != null && _userRepository.CheckPassword(currentUser.PasswordHash, PasswordProtection.Sha256Hash(command.Dto.Password)))
            {


                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserID", currentUser.UserId.ToString()),
                        new Claim("RoleId", "1")
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescription);
                var accessToken = tokenHandler.WriteToken(securityToken);

                return accessToken.ToString();
            } else
            {
                return "Coś poszło nie tak";
            }

            
        }
    }
}
