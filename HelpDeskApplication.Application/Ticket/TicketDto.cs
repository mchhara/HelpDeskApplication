using HelpDeskApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket
{
    public class TicketDto
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ClosedAt { get; set; }
        public string? UserEmail { get; set; }
        public string? AssignedToId { get; set; }
        public PriorityLevel Priority { get; set; }
        public string? EncodedName { get;  set; }
        public bool IsEditable { get; set; }
    }
}
