using Lib.Modules.Auth.Domain.Dtos.Login;
using Lib.Modules.Book.Application.Commands;
using Lib.Modules.Book.Application.Queries;
using Lib.Modules.Book.Domain.Dto;
using Lib.Modules.Book.Domain.Dto.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.WebApi.Controllers
{
    public class BookController : BaseController
    {
        [HttpPost("AddBook")]
        public async Task<ActionResult<string>> AddBook([FromBody] AddBookRequestDto requestDto)
        {
            var result = await Mediator.Send(new AddBook.Command() { Dto = requestDto });
            return Ok(result);
        }

        [HttpPost("AddAuthor")]
        public async Task<ActionResult<string>> AddAuthor([FromBody] AddAuthorRequestDto requestDto)
        {
            var result = await Mediator.Send(new AddAuthor.Command() { Dto = requestDto });
            return Ok(result);
        }

        [HttpGet("AllBooks")]
        public async Task<ActionResult<GetAllBooksDto>> AllBooks()
        {
            var result = await Mediator.Send(new GetAllBooks.Query());
            return Ok(result);
        }

        [HttpGet("BookDetail")]
        public async Task<ActionResult<BookDetailResponseDto>> BookDetail([FromQuery] BookDetailRequestDto requestDto)
        {
            var result = await Mediator.Send(new GetBookDetail.Query() { Dto = requestDto });
            return Ok(result);
        }

        [HttpPost("ChangeBookAvailable")]
        public async Task<ActionResult<string>> ChangeBookAvailable([FromBody] ChangeAvailableRequestDto requestDto)
        {
            var result = await Mediator.Send(new ChangeBookAvailable.Command() { Dto = requestDto });
            return Ok(result);
        }

        [HttpPost("ChangeBookReservation")]
        public async Task<ActionResult<string>> ChangeBookReservation([FromBody] ChangeReservationRequestDto requestDto)
        {
            var result = await Mediator.Send(new ChangeBookReservation.Command() { Dto = requestDto });
            return Ok(result);
        }

        [HttpGet("GetAuthors")]
        public async Task<ActionResult<List<AuthorsResponseDto>>> GetAuthors()
        {
            var result = await Mediator.Send(new GetAutors.Query());
            return Ok(result);
        }

        [HttpGet("GetUserBooks")]
        public async Task<ActionResult<List<AuthorsResponseDto>>> GetUserBooks([FromQuery] BookDetailRequestDto requestDto)
        {
            var result = await Mediator.Send(new GetUserBooks.Query() { Dto = requestDto });
            return Ok(result);
        }

        [HttpPost("BorrowBook")]
        public async Task<ActionResult<string>> BorrowBook([FromBody] BorrowRequestDto requestDto)
        {
            var result = await Mediator.Send(new BorrowBook.Command() { Dto = requestDto });
            return Ok(result);
        }

        [HttpPost("ReturnBook")]
        public async Task<ActionResult<string>> ReturnBook([FromBody] BorrowRequestDto requestDto)
        {
            var result = await Mediator.Send(new ReturnBook.Command() { Dto = requestDto });
            return Ok(result);
        }

        [HttpPost("BookReservation")]
        public async Task<ActionResult<string>> BookReservation([FromBody] BorrowRequestDto requestDto)
        {
            var result = await Mediator.Send(new BookReservation.Command() { Dto = requestDto });
            return Ok(result);
        }

        [HttpGet("GetStatistics")]
        public async Task<ActionResult<List<AuthorsResponseDto>>> GetStatistics()
        {
            var result = await Mediator.Send(new GetBookStatistics.Query());
            return Ok(result);
        }
    }
}
