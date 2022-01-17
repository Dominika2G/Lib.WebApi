using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class BookDetailResponseDto
{
    public long BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsReserved { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
}
