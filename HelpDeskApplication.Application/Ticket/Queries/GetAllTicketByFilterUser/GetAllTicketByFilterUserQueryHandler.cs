using AutoMapper;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilter;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilterUser
{
    public class GetAllTicketByFilterUserQueryHandler : IRequestHandler<GetAllTicketByFilterUserQuery, IEnumerable<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetAllTicketByFilterUserQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketByFilterUserQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetTicketsByCurrentUser(request.Filter);

            var dtos = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return dtos;
        }
    }
}
