using Microsoft.AspNetCore.Identity;
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
        public DateTime CreatedAt { get; set; } 
        public DateTime? ClosedAt { get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public PriorityLevel Priority { get; set; }
        public string? CreateById { get; set; }
        public IdentityUser? CreateBy { get; set; }
        public List<TicketComment>? Comments { get; set; } = new();
        public string EncodedName { get; private set; } = default!;

        public void EncodeName() => EncodedName = Title.ToLower().Replace(" ", "-");
    }
}
