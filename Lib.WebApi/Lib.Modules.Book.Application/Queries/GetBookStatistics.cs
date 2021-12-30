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

public class GetBookStatistics
{
    public class Query : IRequest<BookStatisticsResponseDto>
    {

    }

    public class Handler : IRequestHandler<Query, BookStatisticsResponseDto>
    {
        private readonly IBookViewRepository _bookViewRepository;
        private readonly IMapper _mapper;

        public Handler(IBookViewRepository bookViewRepository, IMapper mapper)
        {
            _bookViewRepository = bookViewRepository;
            _mapper = mapper;
        }

        public async Task<BookStatisticsResponseDto> Handle(Query query, CancellationToken cancellationToken)
        {

            var bookCollection = _bookViewRepository.GetAllAsync().Result;
            var bookCollectionReserved = await _bookViewRepository.GetAllAsync(
                filter: book => book.IsAvailable == true && book.IsReserved == true
                );
            var bookCollectionBorrow =  await _bookViewRepository.GetAllAsync(
                filter: book => book.IsAvailable == false && book.IsReserved == false
                );
            if (bookCollection != null && bookCollectionReserved != null)
            {
                var available = bookCollection.Count;
                var reserved = bookCollectionReserved.Count;
                var borrow = bookCollectionBorrow.Count;
                return new BookStatisticsResponseDto
                {
                    AvailableBook = available - reserved - borrow,
                    ReservedBook = reserved,
                    BorrowedBook = borrow,
                };
            }

            return new BookStatisticsResponseDto();
        }
    }
}
