using Lib.Shared.Abstractions.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.WebApi.Controllers
{
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
    }
}
