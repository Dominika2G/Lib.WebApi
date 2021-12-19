using Lib.Modules.Book.Domain.Dto;
using Lib.Modules.Book.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Commands;

public abstract class AddBook
{
    public class Command : IRequest<string>
    {
        public AddBookRequestDto Dto { get; set; }
    }

    public class Handler : IRequestHandler<Command, string>
    {
        private readonly IBookRepository _bookRepository;

        public Handler(IBookRepository userRepository)
        {
            _bookRepository = userRepository;
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            var newBook = new Lib.Shared.Data.Entities.Book()
            {
                Title = command.Dto.Title,
                AuthorId = command.Dto.AuthorId,
                Description = command.Dto.Description,
                Cover = command.Dto.Cover,
                BarCode = command.Dto.BarCode,
                IsAvailable = command.Dto.IsAvailable
            };

            var isInBase = await _bookRepository.AnyAsync(x => x.BarCode == command.Dto.BarCode);
            if (isInBase)
            {
                return " Taki kod już jest w bazie";
            }
            await _bookRepository.AddAsync(newBook);

            return "Dodano książkę";  
        }
    }
}
