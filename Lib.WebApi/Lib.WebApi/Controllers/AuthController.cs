using Lib.Modules.Auth.Application.Commands;
using Lib.Modules.Auth.Domain.Dtos.Authenticated;
using Lib.Modules.Auth.Domain.Dtos.ChangePassword;
using Lib.Modules.Auth.Domain.Dtos.Login;
using Lib.Modules.Auth.Domain.Dtos.Register;
using Lib.Shared.Abstractions.Contracts;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult<string>> Register([FromBody] RegisterRequestDto requestDto)
    {
        var result = await Mediator.Send(new Register.Command() { Dto = requestDto });
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticatedResponseDto>> Login([FromBody] LoginRequestDto requestDto)
    {
        var result = await Mediator.Send(new Login.Command() { Dto = requestDto });
        return Ok(result);
    }


    //TODO 
    //Niedziałająca metoda
    [Authorize]
    [HttpPost("changePassword")]
    public async Task<ActionResult<string>> Changepassword([FromBody] ChangePasswordRequestDto requestDto)
    {
        var result = await Mediator.Send(new ChangePassword.Command() { Dto = requestDto });
        return Ok(result);
    }
}

