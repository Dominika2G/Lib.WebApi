using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class BookDetailResponseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int IsAvailable { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
}
