﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Domain.Entities
{
    public class TicketComment
    {
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string? UserEmail { get; set; }
        public IdentityUser? CreateBy { get; set; }
        public int TicketId { get; set; } = default!;
        public Ticket Ticket { get; set; } = default!;
    }
}
