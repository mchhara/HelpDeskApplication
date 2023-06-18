using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilterTechnician
{
    public class GetAllTicketByFilterTechnicianQuery : IRequest<IEnumerable<TicketDto>>
    {
    }
}