using MediatR;

namespace HelpDeskApplication.Application.TicketComment.Commands
{
    public class CreateTicketCommentCommand : TicketCommentDto, IRequest
    {
        public string TicketEncodedName { get; set; } = default!;
    }
}
