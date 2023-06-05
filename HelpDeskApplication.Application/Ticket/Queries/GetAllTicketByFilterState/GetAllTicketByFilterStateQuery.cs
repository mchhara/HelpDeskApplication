using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilter
{
    public class GetAllTicketByFilterStateQuery : IRequest<IEnumerable<TicketDto>>
    {
        public string Filter { get; set; }

        public GetAllTicketByFilterStateQuery(string filter)
        {
            Filter = filter;
        }

    }
}
