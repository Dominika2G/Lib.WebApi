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
            
            return _bookRepository.getData();  
        }
    }
}
