using Lib.Modules.Auth.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Application.Queries;

public class GetAllUsers
{
    public class Query : IRequest<string>
    {

    }

    public class Handler : IRequestHandler<Query, string>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(Query query, CancellationToken cancellationToken)
        {

            var userCollection = _userRepository.GetAllAsync().Result;
            if(userCollection != null)
            {
                return "Zwrócono kolekcję userów";
            }
            return "nie można zwrócić kolekcji userów";
        }
    }
}
