using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class AddCommentRequestDto
{
    public string Description { get; set; }
    public int Rating { get; set; }
    public int BookId { get; set; }
}
