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

public class GetBookDetail
{
    public class Query : IRequest<BookDetailResponseDto>
    {
        public BookDetailRequestDto Dto { get; set; }
    }

    public class Handler : IRequestHandler<Query, BookDetailResponseDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public Handler(IBookRepository userRepository, IMapper mapper)
        {
            _bookRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BookDetailResponseDto> Handle(Query query, CancellationToken cancellationToken)
        {
           /* var currentUser = await _userRepository.GetAsync(
                filter: user => user.Email == email
                );*/
            var bookDetail = await _bookRepository.GetAsync(
                filter: book => book.BookId == query.Dto.Id
                );
            var bookDto = _mapper.Map<BookDetailResponseDto>(bookDetail);
            if (bookDto != null)
            {
                return bookDto;
            }

            return new BookDetailResponseDto();
        }
    }
}
