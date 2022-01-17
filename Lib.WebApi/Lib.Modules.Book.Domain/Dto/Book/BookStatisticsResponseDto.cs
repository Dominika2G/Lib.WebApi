using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class BookStatisticsResponseDto
{
    public int AvailableBook { get; set; }
    public int ReservedBook { get; set; }
    public int BorrowedBook { get; set; }
}
