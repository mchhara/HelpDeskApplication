using HelpDeskApplication.Application.ApplicationUser;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.TicketComment.Commands
{
    public class CreateTicketCommentCommandHandler : IRequestHandler<CreateTicketCommentCommand>
    {
        private readonly IUserContext _userContext;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketCommentRepository _ticketCommentRepository;

        public CreateTicketCommentCommandHandler(IUserContext userContext, ITicketRepository ticketRepository,
            ITicketCommentRepository ticketCommentRepository)
        {
            _userContext = userContext;
            _ticketRepository = ticketRepository;
            _ticketCommentRepository = ticketCommentRepository;
        }

        public async Task<Unit> Handle(CreateTicketCommentCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByEncodedName(request.TicketEncodedName!);

            var user = _userContext.GetCurrentUser();
          

            var ticketComment = new Domain.Entities.TicketComment()
            {
                Text = request.Text,
                TicketId = ticket.Id,
                UserEmail = user?.Email
            };

            if (request.HaveSolution)
            {
                ticket.HaveSolution = true;
                await _ticketRepository.HaveSolutionTicketUpdate(ticket); 
            }



            await _ticketCommentRepository.Create(ticketComment);

            return Unit.Value;
        }
    }
}
