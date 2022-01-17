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

public class GetAllBooks
{
    public class Query: IRequest<GetAllBooksDto>
    {
        
    }

    public class Handler : IRequestHandler<Query, GetAllBooksDto>
    {
        private readonly IBookViewRepository _bookViewRepository;
        private readonly IMapper _mapper;

        public Handler(IBookViewRepository bookViewRepository, IMapper mapper)
        {
            _bookViewRepository = bookViewRepository;
            _mapper = mapper;
        }

        public async Task<GetAllBooksDto> Handle(Query query, CancellationToken cancellationToken)
        {

            var bookCollection = _bookViewRepository.GetAllAsync().Result;
            var bookDto = _mapper.Map<List<BookDetailsDto>>(bookCollection);
            if(bookCollection != null)
            {
                return new GetAllBooksDto
                {
                    BookDetails = bookDto
                };
            }

            return new GetAllBooksDto();
        }
    }
}
