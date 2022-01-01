using AutoMapper;
using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Modules.Book.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Queries;

public class GetBookComments
{
    public class Query : IRequest<List<CommentDto>>
    {
        public BookDetailRequestDto Dto { get; set; }
    }

    public class Handler : IRequestHandler<Query, List<CommentDto>>
    {
        private readonly ICommentsViewRepository _commentsViewRepository;
        private readonly IMapper _mapper;

        public Handler(ICommentsViewRepository commentsViewRepository, IMapper mapper)
        {
            _commentsViewRepository = commentsViewRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(Query query, CancellationToken cancellationToken)
        {

            var bookCollection = _commentsViewRepository.GetAllAsync(
                filter: x => x.BookId == query.Dto.Id
                ).Result;
            var bookDto = _mapper.Map<List<CommentDto>>(bookCollection);
            if (bookCollection != null)
            {
                return bookDto;
            }

            return null;
        }
    }
}
