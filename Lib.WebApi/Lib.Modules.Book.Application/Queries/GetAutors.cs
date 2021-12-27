using AutoMapper;
using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Modules.Book.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Queries;

public class GetAutors
{
    public class Query : IRequest<List<AuthorsResponseDto>>
    {

    }

    public class Handler : IRequestHandler<Query, List<AuthorsResponseDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public Handler(IAuthorRepository userRepository, IMapper mapper)
        {
            _authorRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorsResponseDto>> Handle(Query query, CancellationToken cancellationToken)
        {

            var authorCollection = _authorRepository.GetAllAsync().Result;
            var authorDto = _mapper.Map<List<AuthorsResponseDto>>(authorCollection);
            if (authorCollection != null)
            {
                return authorDto;
            }

            return null;
        }
    }
}
