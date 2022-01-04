using Lib.Modules.Auth.Domain.Dtos.Login;
using Lib.Modules.Book.Application.Commands;
using Lib.Modules.Book.Application.Queries;
using Lib.Modules.Book.Domain.Dto;
using Lib.Modules.Book.Domain.Dto.Book;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebApi.Controllers
{
    public class BookController : BaseController
    {
        [Authorize]
        [HttpPost("AddBook")]
        public async Task<ActionResult<string>> AddBook([FromBody] AddBookRequestDto requestDto)
        {
            var result = await Mediator.Send(new AddBook.Command() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpPost("AddAuthor")]
        public async Task<ActionResult<string>> AddAuthor([FromBody] AddAuthorRequestDto requestDto)
        {
            var result = await Mediator.Send(new AddAuthor.Command() { Dto = requestDto });
            return Ok(result);
        }
        [Authorize]
        [HttpGet("AllBooks")]
        public async Task<ActionResult<GetAllBooksDto>> AllBooks()
        {
            var userId = User.Claims.First(x => x.Type == "UserID");
            var result = await Mediator.Send(new GetAllBooks.Query());
            return Ok(result);
        }

        /*[Authorize]
        [HttpGet("BookDetail")]
        public async Task<ActionResult<BookDetailResponseDto>> BookDetail([FromQuery] BookDetailRequestDto requestDto)
        {
            var result = await Mediator.Send(new GetBookDetail.Query() { Dto = requestDto });
            var commentResult = await Mediator.Send(new GetBookComments.Query());
            return Ok(result);
        }*/
        [Authorize]
        [HttpGet("BookDetail")]
        public async Task<ActionResult<BookDetailWithCommentsResponseDto>> BookDetail([FromQuery] BookDetailRequestDto requestDto)
        {
            var result = await Mediator.Send(new GetBookDetail.Query() { Dto = requestDto });
            var commentResult = await Mediator.Send(new GetBookComments.Query() { Dto = requestDto} );
            float rating = 0;
            foreach(var tmp in commentResult)
            {
                rating += tmp.Rating;
            }
            if(commentResult.Count > 0)
            {
                rating /= commentResult.Count;
            }
            var newResult = new BookDetailWithCommentsResponseDto()
            {
                BookDetails = result,
                CommentList = commentResult,
                Rating = rating
            };
            return Ok(newResult);
        }

        [Authorize]
        [HttpPost("ChangeBookAvailable")]
        public async Task<ActionResult<string>> ChangeBookAvailable([FromBody] ChangeAvailableRequestDto requestDto)
        {
            var result = await Mediator.Send(new ChangeBookAvailable.Command() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpPost("ChangeBookReservation")]
        public async Task<ActionResult<string>> ChangeBookReservation([FromBody] ChangeReservationRequestDto requestDto)
        {
            var result = await Mediator.Send(new ChangeBookReservation.Command() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetAuthors")]
        public async Task<ActionResult<List<AuthorsResponseDto>>> GetAuthors()
        {
            var result = await Mediator.Send(new GetAutors.Query());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUserBooks")]
        public async Task<ActionResult<List<AuthorsResponseDto>>> GetUserBooks([FromQuery] BookDetailRequestDto requestDto)
        {
            var result = await Mediator.Send(new GetUserBooks.Query() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUserLoginBooks")]
        public async Task<ActionResult<List<AuthorsResponseDto>>> GetUserLoginBooks()
        {
            var userId = User.Claims.First(x => x.Type == "UserID");
            var requestDto = new BookDetailRequestDto()
            {
                Id = long.Parse(userId.Value)
            };
            var result = await Mediator.Send(new GetUserBooks.Query() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpPost("BorrowBook")]
        public async Task<ActionResult<string>> BorrowBook([FromBody] BorrowRequestDto requestDto)
        {
            var result = await Mediator.Send(new BorrowBook.Command() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpPost("ReturnBook")]
        public async Task<ActionResult<string>> ReturnBook([FromBody] ReturnBookRequestDto requestDto)
        {
            var result = await Mediator.Send(new ReturnBook.Command() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpPost("BookReservation")]
        public async Task<ActionResult<string>> BookReservation([FromBody] BorrowRequestDto requestDto)
        {
            if(requestDto.UserId == 0)
            {
                var userId = User.Claims.First(x => x.Type == "UserID");
                requestDto.UserId = long.Parse(userId.Value);
            }
            var result = await Mediator.Send(new BookReservation.Command() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetStatistics")]
        public async Task<ActionResult<List<AuthorsResponseDto>>> GetStatistics()
        {
            var result = await Mediator.Send(new GetBookStatistics.Query());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetSelectedBook")]
        public async Task<ActionResult<GetAllBooksDto>> GetSelectedBook([FromQuery] SelectedBookRequestDto requestDto)
        {
            var result = await Mediator.Send(new GetSelectedBook.Query() { Dto = requestDto });
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetBooksinformation")]
        public async Task<ActionResult<BooksStatisticsInfResponseDto>> GetBooksInformation()
        {
            var result = await Mediator.Send(new GetAllBookInformation.Query());
            return Ok(result);
        }

        [Authorize]
        [HttpPost("AddComment")]
        public async Task<ActionResult<string>> AddComment([FromBody]AddCommentRequestDto requestDto)
        {
            var userId = User.Claims.First(x => x.Type == "UserID");
            var result = await Mediator.Send(new AddComment.Command() { Dto = requestDto, UserId = long.Parse(userId.Value) });
            return Ok(result);
        }

        [Authorize]
        [HttpGet("AllComments")]
        public async Task<ActionResult<List<CommentDto>>> AllComments()
        {
            //var userId = User.Claims.First(x => x.Type == "UserID");
            var result = await Mediator.Send(new GetBookComments.Query());
            return Ok(result);
        }
    }
}
