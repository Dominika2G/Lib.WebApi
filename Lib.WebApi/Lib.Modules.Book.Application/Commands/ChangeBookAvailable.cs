using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Modules.Book.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Commands;

public abstract class ChangeBookAvailable
{
    public class Command : IRequest<string>
    {
        public ChangeAvailableRequestDto Dto { get; set; }
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
            var available = currentBook.IsAvailable;
            if(available == true)
            {
                currentBook.IsAvailable = false;
            }else
            {
                currentBook.IsAvailable = true;
            }

            _bookRepository.Update(currentBook);

            return "Dostępność książki została zmieniona";
        }
    }
}
