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

public class GetUsersStatistics
{
    public class Query : IRequest<UserStatisticsResponseDto>
    {

    }

    public class Handler : IRequestHandler<Query, UserStatisticsResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public Handler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserStatisticsResponseDto> Handle(Query query, CancellationToken cancellationToken)
        {
            var userDisabled = _userRepository.GetAllAsync(
                filter: user => user.IsActive == false
                ).Result. Count;
            var userAvailable = _userRepository.GetAllAsync(
                filter: user => user.IsActive == true
                ).Result.Count;
            if (userDisabled != null)
            {
                return new UserStatisticsResponseDto
                {
                    AvailableUsers = userAvailable,
                    DisabledUsers = userDisabled
                };
            }
            return new UserStatisticsResponseDto();
        }
    }
}
