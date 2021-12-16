using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Shared.Abstractions.Contracts
{
    public class BaseResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
