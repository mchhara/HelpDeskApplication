using AutoMapper;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;


namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTickets
{
    internal class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetAllTicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return dtos;
        }
    }
}
