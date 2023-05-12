using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Commands.EditTicket
{
    public class EditTicketCommand : TicketDto, IRequest
    {
    }
}
