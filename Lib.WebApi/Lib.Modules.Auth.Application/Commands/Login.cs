using Lib.Modules.Auth.Domain.Dtos.Authenticated;
using Lib.Modules.Auth.Domain.Dtos.Login;
using Lib.Modules.Auth.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (currentUser == null)
            {
                return "Coś poszło nie tak";
            }

            return "Dostałam użytkownika";
        }
    }
}
