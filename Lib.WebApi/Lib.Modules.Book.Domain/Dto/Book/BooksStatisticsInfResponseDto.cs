using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class BooksStatisticsInfResponseDto
{
    public List<GetUsersBookResponseDto> BorrowBooks { get; set; }
    public List<BookDetailResponseDto> AllBooks { get; set; }
}
