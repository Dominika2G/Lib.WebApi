using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Dtos
{
    public class GetAllBooksDto
    {
        public List<BookDetailsDto> BookDetails { get; set; }
    }
}
