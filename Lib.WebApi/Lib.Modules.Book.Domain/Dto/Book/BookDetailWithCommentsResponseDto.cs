using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class BookDetailWithCommentsResponseDto
{
    public BookDetailResponseDto BookDetails { get; set; }
    public List<CommentDto> CommentList { get; set; }
}
