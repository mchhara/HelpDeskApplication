using AutoMapper;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTickets;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;


namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilter
{
    public class GetAllTicketByFilterQueryHandler : IRequestHandler<GetAllTicketByFilterQuery, IEnumerable<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetAllTicketByFilterQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketByFilterQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetTicketsByStatus(request.Filter); ;
            var dtos = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return dtos;
        }
    }
}
