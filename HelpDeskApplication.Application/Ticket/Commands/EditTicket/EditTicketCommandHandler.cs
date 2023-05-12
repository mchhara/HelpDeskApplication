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

        public EditTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<Unit> Handle(EditTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByEncodedName(request.EncodedName!);

            ticket.Title = request.Title;
            ticket.Description = request.Description;
            ticket.Priority = request.Priority;

           await _ticketRepository.Commit();

           return Unit.Value;
        }
    }
}
