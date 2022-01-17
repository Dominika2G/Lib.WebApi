using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class ChangeReservationRequestDto
{
    public long BookId { get; set; }
    public bool IsReserved { get; set; }
}
