using Lib.Modules.Book.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Queries;

public class GetAllBooks
{
    public class Query: IRequest<string>
    {
        
    }

    public class Handler : IRequestHandler<Query, string>
    {
        private readonly IBookRepository _bookRepository;

        public Handler(IBookRepository userRepository)
        {
            _bookRepository = userRepository;
        }

        public async Task<string> Handle(Query query, CancellationToken cancellationToken)
        {

            var bookCollection = _bookRepository.GetAllAsync().Result;

            if(bookCollection != null)
            {
                return "Zwrócono kolekcję książek";
            }

            return "Nie można zwrócić kolekcji książek";
        }
    }
}
