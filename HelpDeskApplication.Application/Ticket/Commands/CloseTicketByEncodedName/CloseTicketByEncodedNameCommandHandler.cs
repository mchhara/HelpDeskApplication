using AutoMapper;
using HelpDeskApplication.Application.Ticket.Commands.GetTicketByEncodedName;
using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Commands.CloseTicketByEncodedName
{
    public class CloseTicketByEncodedNameCommandHandler : IRequestHandler<CloseTicketByEncodedNameCommand, TicketDto>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public CloseTicketByEncodedNameCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<TicketDto> Handle(CloseTicketByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByEncodedName(request.EncodedName);

            ticket.Status = TicketStatus.Closed;
            ticket.ClosedAt = DateTime.UtcNow;
            await _ticketRepository.Commit();


            var dto = _mapper.Map<TicketDto>(ticket);

            return dto;
        }
    }
}
