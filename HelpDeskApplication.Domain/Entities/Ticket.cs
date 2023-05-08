using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelpDeskApplication.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ClosedAt { get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public PriorityLevel Priority { get; set; } = PriorityLevel.Low;
        public List<TicketComments>? Comments { get; set; }
        public string EncodedName { get; private set; } = default!;

        public void EncodeName() => EncodedName = Title.ToLower().Replace(" ", "-");
    }
}
