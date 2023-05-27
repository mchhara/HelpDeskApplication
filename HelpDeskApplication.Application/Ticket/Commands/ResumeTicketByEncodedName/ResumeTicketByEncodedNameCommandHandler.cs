using AutoMapper;
using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Commands.GetTicketByEncodedName
{
    public class ResumeTicketByEncodedNameCommandHandler : IRequestHandler<ResumeTicketByEncodedNameCommand, TicketDto>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public ResumeTicketByEncodedNameCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<TicketDto> Handle(ResumeTicketByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByEncodedName(request.EncodedName);

            ticket.Status = TicketStatus.Open;
            ticket.ClosedAt = null;
            ticket.HaveSolution = false;
            await _ticketRepository.Commit();


            var dto = _mapper.Map<TicketDto>(ticket);

            return dto;
        }
    }
}
