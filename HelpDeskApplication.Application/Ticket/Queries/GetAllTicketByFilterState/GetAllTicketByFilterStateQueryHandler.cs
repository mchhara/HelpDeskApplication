using AutoMapper;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTickets;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;


namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilter
{
    public class GetAllTicketByFilterStateQueryHandler : IRequestHandler<GetAllTicketByFilterStateQuery, IEnumerable<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetAllTicketByFilterStateQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketByFilterStateQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetTicketsByStatus(request.Filter);

            var dtos = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return dtos;
        }
    }
}
