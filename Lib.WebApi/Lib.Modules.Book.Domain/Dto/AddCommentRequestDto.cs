using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto;

public class AddCommentRequestDto
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Rating { get; set; }
}
