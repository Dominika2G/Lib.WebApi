using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto;

public class AddBookRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long AuthorId { get; set; }
    public string Cover { get; set; }
    public string BarCode { get; set; }
    public int IsAvailable { get; set; }

}
