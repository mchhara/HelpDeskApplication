using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.TicketComment.Commands
{
    public class CreateTicketCommentCommandValidator : AbstractValidator<CreateTicketCommentCommand>
    {
        public CreateTicketCommentCommandValidator()
        {
            RuleFor(s => s.Text).NotEmpty().NotNull();
        }
    }
}
