using AutoMapper;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilter;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketBySearchTitle
{
    public class GetAllTicketBySearchTitleQueryHandler : IRequestHandler<GetAllTicketBySearchTitleQuery, IEnumerable<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public GetAllTicketBySearchTitleQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketBySearchTitleQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _ticketRepository.GetTicketsBySearchName(request.Title); ;
        var dtos = _mapper.Map<IEnumerable<TicketDto>>(tickets);

        return dtos;
    }
}
}