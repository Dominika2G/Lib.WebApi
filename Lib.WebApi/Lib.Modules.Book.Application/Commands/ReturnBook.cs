using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Modules.Book.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Commands;

public class ReturnBook
{
    public class Command : IRequest<string>
    {
        public ReturnBookRequestDto Dto { get; set; }
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
            var findBorrowedBook = await _borrowRepository.GetAsync(
                filter: borrow => borrow.BookId == command.Dto.BookId   
                );

            if (findBorrowedBook == null)
            {
                return "Nie znaleziono rekordu do usuniecia";
            }

            _borrowRepository.Delete(findBorrowedBook);

            var findBook = await _bookRepository.GetAsync(
                filter: book => book.BookId == command.Dto.BookId
                );
            if (findBook == null)
            {
                return "Nie znaleziono ksiązki";
            }

            findBook.IsReserved = false;
            findBook.IsAvailable = true;

            _bookRepository.Update(findBook);

            return "Wypożyczono";
        }
    }
}
