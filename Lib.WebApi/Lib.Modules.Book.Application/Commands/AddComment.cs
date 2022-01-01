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

public abstract class AddComment
{
    public class Command : IRequest<string>
    {
        public AddCommentRequestDto Dto { get; set; }
        public long UserId { get; set; }
    }

    public class Handler : IRequestHandler<Command, string>
    {
        private readonly ICommentBookRepository _commentBookRepository;
        private readonly ICommentRepository _commentRepository; 

        public Handler(ICommentBookRepository commentBookRepository, ICommentRepository commentRepository)
        {
            _commentBookRepository = commentBookRepository;
            _commentRepository = commentRepository;
        }

        public async Task<string> Handle(Command command, CancellationToken cancellationToken)
        {
            var newComment = new Comment()
            {
                UserId = command.UserId,
                Description = command.Dto.Description,
                AddingDate = DateTime.Today,
                Rating = command.Dto.Rating,
            };

            await _commentRepository.AddAsync(newComment);

            var findComment = await _commentRepository.GetAsync(
                filter: tmp => tmp.Description == newComment.Description && tmp.UserId == newComment.UserId
                );

            if (findComment != null)
            {
                var newBookComment = new CommentsBook()
                {
                    BookId = command.Dto.BookId,
                    CommentId = findComment.CommentId
                };
                await _commentBookRepository.AddAsync(newBookComment);
            }

            return "Dodano komentarz";
        }
    }
}
