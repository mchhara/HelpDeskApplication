using AutoMapper;
using HelpDeskApplication.Application.Ticket.Commands.CloseTicketByEncodedName;
using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetTicketByEncodedNameQuery
{
    public class GetTicketByEncodedNameQueryHandler : IRequestHandler<GetTicketByEncodedNameQuery, TicketDto>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetTicketByEncodedNameQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<TicketDto> Handle(GetTicketByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<TicketDto>(ticket);

            return dto;
        }
    }
}