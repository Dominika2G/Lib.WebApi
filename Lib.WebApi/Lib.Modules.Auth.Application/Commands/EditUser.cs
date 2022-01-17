using Lib.Modules.Auth.Domain.Dtos.User;
using Lib.Modules.Auth.Domain.Interfaces;
using Lib.Modules.Auth.Infrastructure.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Application.Commands;

public class EditUser
{
    public class Command : IRequest<string>
    {
        public EditUserRequestDto Dto { get; set; }
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
            var id = command.Dto.UserId;

            var currentUser = await _userRepository.GetAsync(
                filter: user => user.UserId == id
                );
            if (currentUser == null)
            {
                return "Nie znaleziono użytkownika";
            }

            if (!string.IsNullOrEmpty(command.Dto.FirstName))
            {
                currentUser.FirstName = command.Dto.FirstName;
            }

            if (!string.IsNullOrEmpty(command.Dto.LastName))
            {
                currentUser.LastName = command.Dto.LastName;
            }

            if (!string.IsNullOrEmpty(command.Dto.Email))
            {
                currentUser.Email = command.Dto.Email;
            }

            if (command.Dto.IsActive != currentUser.IsActive)
            {
                currentUser.IsActive = command.Dto.IsActive;
            }

            if (!string.IsNullOrEmpty(command.Dto.Class))
            {
                currentUser.Class = command.Dto.Class;
            }

            if (!string.IsNullOrEmpty(command.Dto.Password))
            {
                currentUser.PasswordHash = PasswordProtection.Sha256Hash(command.Dto.ConfirmPassword);
            }

            _userRepository.Update(currentUser);

            return "Update Usera";
        }
    }
}
