using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Modules.Book.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Commands;

public class ChangeBookReservation
{
    public class Command : IRequest<string>
    {
        public ChangeReservationRequestDto Dto { get; set; }
    }

    public class Handler : IRequestHandler<Command, string>
    {
        private readonly IBookRepository _bookRepository;

        public Handler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {

            var currentBook = await _bookRepository.GetAsync(
                filter: book => book.BookId == command.Dto.BookId
                );
            if (currentBook == null)
            {
                return "Nie znaleziono książki";
            }
            var reserved = currentBook.IsReserved;
            if (reserved == command.Dto.IsReserved)
            {
                return "Stan rezerwacji nie uległ zmianie";
            }

            currentBook.IsReserved = command.Dto.IsReserved;

            _bookRepository.Update(currentBook);

            return "Zmieniono status rezerwacji";
        }
    }
}
