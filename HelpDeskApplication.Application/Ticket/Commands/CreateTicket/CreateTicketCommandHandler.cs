using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper, IUserContext userContext)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

     
        public async Task<Unit> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {   
            var currentUser = _userContext.GetCurrentUser();
            if(currentUser == null || !currentUser.IsInRole("User")) 
            {
                return Unit.Value;
            }

            var ticket = _mapper.Map<Domain.Entities.Ticket>(request);

            ticket.EncodeName();

            ticket.CreateById = currentUser.Id;

            await _ticketRepository.Create(ticket);

            return Unit.Value;
        }
    }

}

