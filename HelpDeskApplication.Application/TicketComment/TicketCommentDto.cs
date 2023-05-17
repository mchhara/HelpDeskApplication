using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.TicketComment
{
    public class TicketCommentDto
    {
        public string Text { get; set; } = default!;
        public string? UserEmail { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
