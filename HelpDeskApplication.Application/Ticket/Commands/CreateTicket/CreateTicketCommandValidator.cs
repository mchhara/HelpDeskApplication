using FluentValidation;
using HelpDeskApplication.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Commands.CreateTicket
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator(ITicketRepository repository)
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Title should have atleast 2 characters")
                .MaximumLength(20).WithMessage("Title should have maximum 20 characters")
                .Custom((value, context) =>
                {
                    var exsistingTicket = repository.GetByTitle(value).Result;
                    if (exsistingTicket != null)
                    {
                        context.AddFailure($"{value} is not unique title for ticket");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.Priority)
                 .NotNull().WithMessage("Please select priority level");

            RuleFor(c => c.AssignedToId)
                .NotEmpty().WithMessage("Assign technician to ticket");
        }
    }
}
