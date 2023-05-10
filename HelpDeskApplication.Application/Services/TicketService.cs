using AutoMapper;
using HelpDeskApplication.Application.Ticket;
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
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task Create(TicketDto ticketDto)
        {
           var ticket = _mapper.Map<Domain.Entities.Ticket>(ticketDto);

            ticket.EncodeName();
            await _ticketRepository.Create(ticket);
        }
    }
}
