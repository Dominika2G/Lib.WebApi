using Lib.Modules.Auth.Domain.Dtos.Login;
using Lib.Modules.Book.Application.Commands;
using Lib.Modules.Book.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lib.WebApi.Controllers
{
    public class BookController : BaseController
    {
        [HttpPost("AddBook")]
        public async Task<ActionResult<string>> AddBook()
        {
            var result = await Mediator.Send(new AddBook.Command());
            return Ok(result);
        }

        [HttpPost("AddAuthor")]
        public async Task<ActionResult<string>> AddAuthor([FromBody] AddAuthorRequestDto requestDto)
        {
            var result = await Mediator.Send(new AddAuthor.Command() { Dto = requestDto });
            return Ok(result);
        }
    }
}
