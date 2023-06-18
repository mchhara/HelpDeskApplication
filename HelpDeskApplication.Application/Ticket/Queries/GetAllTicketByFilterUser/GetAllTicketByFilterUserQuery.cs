using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilterUser
{
    public class GetAllTicketByFilterUserQuery : IRequest<IEnumerable<TicketDto>>
    {
    }
}