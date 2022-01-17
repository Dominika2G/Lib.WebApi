using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Domain.Dtos.User;

public class UserStatisticsResponseDto
{
    public int AvailableUsers { get; set; }
    public int DisabledUsers { get; set; }
}
