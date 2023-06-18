using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilterUser;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilterTechnician
{
    public class GetAllTicketByFilterTechnicianQueryHandler : IRequestHandler<GetAllTicketByFilterTechnicianQuery, IEnumerable<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public GetAllTicketByFilterTechnicianQueryHandler(ITicketRepository ticketRepository, IMapper mapper, IUserContext userContext)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketByFilterTechnicianQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
           
            var tickets = await _ticketRepository.GetTicketsByCurrentTechnician(currentUser.Id);
            var dtos = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return dtos;
        }
    }
}
