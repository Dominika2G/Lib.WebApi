using Lib.Modules.Book.Domain.Dto;
using Lib.Modules.Book.Domain.Interfaces;
using Lib.Shared.Data.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Commands;

public abstract class AddAuthor
{
    public class Command : IRequest<string>
    {
        public AddAuthorRequestDto Dto { get; set; }
    }

    public class Handler : IRequestHandler<Command, string>
    {
        private readonly IAuthorRepository _authorRepository;

        public Handler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            if(await _authorRepository.AnyAsync(x => x.FirstName == command.Dto.FirstName && x.LastName == command.Dto.LastName))
            {
                return "Autor już istnieje";
            }
            var newAuthoe = new Author()
            {
                FirstName = command.Dto.FirstName,
                LastName = command.Dto.LastName
            };

            await _authorRepository.AddAsync(newAuthoe);
            return "Udało się dodać nowego autora";
        }
    }
}
