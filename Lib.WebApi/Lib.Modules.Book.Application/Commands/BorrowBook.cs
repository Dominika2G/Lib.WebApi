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

public class BorrowBook
{
    public class Command : IRequest<string>
    {
        public BorrowRequestDto Dto { get; set; }
    }

    public class Handler : IRequestHandler<Command, string>
    {
        private readonly IBorrowRepository _borrowRepository;

        public Handler(IBorrowRepository borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            var newBorrow = new Borrow
            {
                UserId = command.Dto.UserId,
                BookId = command.Dto.BookId,
                LoanDate = DateTime.Today,
                ReturnDate = DateTime.Today
            };

            await _borrowRepository.AddAsync(newBorrow);

            return "Wypożyczono";
        }
    }
}
