using Lib.Modules.Auth.Domain.Dtos.Register;
using Lib.Modules.Auth.Domain.Interfaces;
using Lib.Modules.Auth.Infrastructure.Helpers;
using Lib.Shared.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Application.Commands
{
    public class  Register
    {
        public class Command: IRequest<string>
        {
            public RegisterRequestDto Dto { get; set; }
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
                var newUser = new User()
                {
                    FirstName = "Test1",
                    LastName = "Test1",
                    Email = "Test1",
                    RoleId = 1,
                    PasswordHash = PasswordProtection.Sha256Hash("password"),
                    Class = "5c"
                };

                await _userRepository.AddAsync(newUser);
                return _userRepository.getData();
            }
        }
    }
}
