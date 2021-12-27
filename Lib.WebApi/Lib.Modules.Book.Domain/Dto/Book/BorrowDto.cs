﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Domain.Dto.Book;

public class BorrowDto
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public long ReturnDate { get; set; }
}
