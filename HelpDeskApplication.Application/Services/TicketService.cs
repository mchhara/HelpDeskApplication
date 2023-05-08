using HelpDeskApplication.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task Create(Domain.Entities.Ticket ticket)
        {
            ticket.EncodeName();
            await _ticketRepository.Create(ticket);
        }
    }
}
