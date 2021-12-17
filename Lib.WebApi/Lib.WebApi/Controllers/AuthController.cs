using Lib.Modules.Auth.Application.Commands;
using Lib.Shared.Abstractions.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebApi.Controllers;

public class AuthController : BaseController
{
    [HttpGet]
    public ActionResult<BaseResponse> Get()
    {
        var response = new BaseResponse
        {
            Status = "success",
            Message = "I'm working fine!"
        };
        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register()
    {
        var result = await Mediator.Send(new Register.Command());
        return Ok(result);
    }
}

