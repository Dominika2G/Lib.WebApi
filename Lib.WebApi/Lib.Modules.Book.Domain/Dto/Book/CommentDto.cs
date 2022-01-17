using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class CommentDto
{
    public string Description { get; set; }
    public string Email { get; set; }
    public DateTime AddingDate { get; set; }
    public int Rating { get; set; }
}
