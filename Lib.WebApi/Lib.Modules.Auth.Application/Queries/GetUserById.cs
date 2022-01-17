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

public class GetUserById
{
    public class Query : IRequest<UserDetailDto>
    {
        public long Dto { get; set; }
    }

    public class Handler : IRequestHandler<Query, UserDetailDto>
    {
        private readonly IUserViewRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(IUserViewRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailDto> Handle(Query query, CancellationToken cancellationToken)
        {

            var userCollection = _userRepository.GetAsync(
                filter: user => user.UserId == query.Dto
                ).Result;
            var userDto = _mapper.Map<UserDetailDto>(userCollection);
            if (userCollection != null)
            {
                return userDto;
            }
            return new UserDetailDto();
        }
    }
}
