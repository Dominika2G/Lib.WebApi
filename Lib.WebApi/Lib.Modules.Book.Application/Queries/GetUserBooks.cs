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

public class GetUserBooks
{
    public class Query : IRequest<List<GetUsersBookResponseDto>>
    {
        public BookDetailRequestDto Dto { get; set; } 
    }

    public class Handler : IRequestHandler<Query, List<GetUsersBookResponseDto>>
    {
        private readonly IBorrowRepository _bookViewRepository;
        private readonly IBorrowViewRepository _borrowViewRepository;
        private readonly IMapper _mapper;

        public Handler(IBorrowRepository bookViewRepository, IBorrowViewRepository borrowViewRepository, IMapper mapper)
        {
            _bookViewRepository = bookViewRepository;
            _borrowViewRepository = borrowViewRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUsersBookResponseDto>> Handle(Query query, CancellationToken cancellationToken)
        {

            var bookCollection = _borrowViewRepository.GetAllAsync(filter: book => book.UserId == query.Dto.Id).Result;
            var bookDto = _mapper.Map<List<GetUsersBookResponseDto>>(bookCollection);
            if (bookCollection != null)
            {
                return bookDto;
            }

            return null;
        }
    }
}
