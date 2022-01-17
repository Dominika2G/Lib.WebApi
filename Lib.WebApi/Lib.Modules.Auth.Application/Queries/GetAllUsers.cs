using AutoMapper;
using Lib.Modules.Auth.Domain.Dtos.User;
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
    public class Query : IRequest<UsersCollectionResponseDto>
    {

    }

    public class Handler : IRequestHandler<Query, UsersCollectionResponseDto>
    {
        private readonly IUserViewRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(IUserViewRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UsersCollectionResponseDto> Handle(Query query, CancellationToken cancellationToken)
        {

            var userCollection = _userRepository.GetAllAsync().Result;
            var userDto = _mapper.Map<List<UserDetailDto>>(userCollection);
            if(userCollection != null)
            {
                return new UsersCollectionResponseDto
                {
                    UsersCollection = userDto
                };
            }
            return new UsersCollectionResponseDto();
        }
    }
}
