using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Shared.Data.Entities
{
    public class CommentsView
    {
        public string Description { get; set; }
        public DateTime AddingDate { get; set; }
        public int Rating { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public long CommentId { get; set; }
    }
}
