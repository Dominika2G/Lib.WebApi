using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Modules.Auth.Domain.Dtos.Register
{
    public class RegisterRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Class { get; set; }
    }
}
