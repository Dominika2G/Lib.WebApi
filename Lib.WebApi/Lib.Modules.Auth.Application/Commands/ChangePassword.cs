using Lib.Modules.Auth.Domain.Dtos.ChangePassword;
using Lib.Modules.Auth.Domain.Interfaces;
using Lib.Modules.Auth.Infrastructure.Helpers;
using Lib.Shared.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Application.Commands;

public abstract class ChangePassword
{
    public class Command : IRequest<string>
    {
        public ChangePasswordRequestDto Dto { get; set; }
    }

    public class Handler : IRequestHandler<Command, string>
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
                return "Nie znaleziono użytkownika";
            }
            if (command.Dto.OldPassword == command.Dto.NewPassword)
            {
                return "Podałeś to samo hasło";

            }

            currentUser.PasswordHash = PasswordProtection.Sha256Hash(command.Dto.NewPassword);

            _userRepository.Update(currentUser);

            return "Hasło zmienione";
        }
    }
}
