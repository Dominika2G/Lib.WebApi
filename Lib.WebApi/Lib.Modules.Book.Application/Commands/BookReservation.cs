using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Modules.Book.Domain.Interfaces;
using Lib.Shared.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Commands;

public class BookReservation
{
    public class Command : IRequest<string>
    {
        public BorrowRequestDto Dto { get; set; }
    }

    public class Handler : IRequestHandler<Command, string>
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;

        public Handler(IBorrowRepository borrowRepository, IBookRepository bookRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            var newBorrow = new Borrow
            {
                UserId = command.Dto.UserId,
                BookId = command.Dto.BookId,
                LoanDate = DateTime.Today,
                ReturnDate = DateTime.Today.AddDays(14),
                RentalPeriod = 14
            };

            await _borrowRepository.AddAsync(newBorrow);

            var findBook = await _bookRepository.GetAsync(
                filter: book => book.BookId == command.Dto.BookId
                );
            if (findBook == null)
            {
                return "Nie znaleziono ksiązki";
            }

            findBook.IsReserved = true;
            findBook.IsAvailable = true;

            _bookRepository.Update(findBook);

            return "zarezerwowano";
        }
    }
}
