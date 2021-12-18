using Lib.Modules.Auth.Domain.Dtos.Login;
using Lib.Modules.Book.Application.Commands;
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
    }
}
