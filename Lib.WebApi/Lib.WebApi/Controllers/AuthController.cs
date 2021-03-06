using Lib.Modules.Auth.Application.Commands;
using Lib.Modules.Auth.Application.Queries;
using Lib.Modules.Auth.Domain.Dtos.Authenticated;
using Lib.Modules.Auth.Domain.Dtos.ChangePassword;
using Lib.Modules.Auth.Domain.Dtos.Login;
using Lib.Modules.Auth.Domain.Dtos.Register;
using Lib.Modules.Auth.Domain.Dtos.User;
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

    [Authorize]
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

    [Authorize]
    [HttpGet("getUsers")]
    public async Task<ActionResult<UsersCollectionResponseDto>> GetUsers()
    {
        var result = await Mediator.Send(new GetAllUsers.Query());
        return Ok(result);
    }

    [Authorize]
    [HttpPost("changePassword")]
    public async Task<ActionResult<string>> Changepassword([FromBody] ChangePasswordRequestDto requestDto)
    {
        var email = User.Claims.First(x => x.Type == "Email");
        var result = await Mediator.Send(new ChangePassword.Command() { Dto = requestDto, Email = email.Value });
        return Ok(result);
    }

    [Authorize]
    [HttpPost("editUser")]
    public async Task<ActionResult<string>> EditUser([FromBody] EditUserRequestDto requestDto)
    {
        var result = await Mediator.Send(new EditUser.Command() { Dto = requestDto });
        return Ok(result);
    }

    [Authorize]
    [HttpGet("getUsersStatistics")]
    public async Task<ActionResult<UserStatisticsResponseDto>> GetUsersStatistics()
    {
        var result = await Mediator.Send(new GetUsersStatistics.Query());
        return Ok(result);
    }

    [Authorize]
    [HttpGet("getUser")]
    public async Task<ActionResult<UserDetailDto>> GetUser([FromQuery] long requestDto)
    {
        var result = await Mediator.Send(new GetUserById.Query() { Dto = requestDto });
        return Ok(result);
    }
}

