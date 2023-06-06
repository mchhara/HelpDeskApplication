using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public GetAllTicketByFilterUserQueryHandler(ITicketRepository ticketRepository, IMapper mapper, IUserContext userContext)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _userContext  = userContext;
        }

        public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketByFilterUserQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            if (currentUser!.IsInRole("User"))
            {
                var userTickets = await _ticketRepository.GetTicketsByCurrentUser(request.Filter);
                var userDtos = _mapper.Map<IEnumerable<TicketDto>>(userTickets);

                return userDtos;
            }
            var tickets = await _ticketRepository.GetTicketsByCurrentTechnician(request.Filter);

            var dtos = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return dtos;
        }
    }
}
