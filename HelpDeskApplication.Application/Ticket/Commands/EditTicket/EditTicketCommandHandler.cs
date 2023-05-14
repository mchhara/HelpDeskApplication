using HelpDeskApplication.Application.ApplicationUser;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Commands.EditTicket
{
    internal class EditTicketCommandHandler : IRequestHandler<EditTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserContext _userContext;

        public EditTicketCommandHandler(ITicketRepository ticketRepository, IUserContext userContext)
        {
            _ticketRepository = ticketRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (ticket.CreateById == user.Id || user.IsInRole("Technician"));

            if(!isEditable)
            {
                return Unit.Value;
            }

            ticket.Title = request.Title;
            ticket.Description = request.Description;
            ticket.Priority = request.Priority;

           await _ticketRepository.Commit();

           return Unit.Value;
        }
    }
}
