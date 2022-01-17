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

public class GetAllBookInformation
{
    public class Query : IRequest<BooksStatisticsInfResponseDto>
    {
    }

    public class Handler : IRequestHandler<Query, BooksStatisticsInfResponseDto>
    {
        private readonly IBorrowViewRepository _borrowViewRepository;
        private readonly IBookViewRepository _bookViewRepository;
        private readonly IMapper _mapper;

        public Handler(IBorrowViewRepository borrowViewRepository, IBookViewRepository bookViewRepository, IMapper mapper)
        {
            _borrowViewRepository = borrowViewRepository;
            _bookViewRepository = bookViewRepository;
            _mapper = mapper;
        }

        public async Task<BooksStatisticsInfResponseDto> Handle(Query query, CancellationToken cancellationToken)
        {

            var borrowCollection = _borrowViewRepository.GetAllAsync().Result;
            var bookCollection = _bookViewRepository.GetAllAsync().Result;
            var borrowDto = _mapper.Map<List<GetUsersBookResponseDto>>(borrowCollection);
            var bookDto = _mapper.Map<List<BookDetailResponseDto>>(bookCollection);
            if (borrowCollection != null && bookCollection != null)
            {
                return new BooksStatisticsInfResponseDto()
                {
                    BorrowBooks = borrowDto,
                    AllBooks = bookDto
                };
            }

            return new BooksStatisticsInfResponseDto();
        }
    }
}
