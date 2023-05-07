using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Domain.Entities
{
    public class TicketComments
    {
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public DateTime DateCreated { get; set; }
    }
}
