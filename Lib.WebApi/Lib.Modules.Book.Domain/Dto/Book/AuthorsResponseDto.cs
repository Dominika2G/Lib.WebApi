using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class AuthorsResponseDto
{
    public long AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
