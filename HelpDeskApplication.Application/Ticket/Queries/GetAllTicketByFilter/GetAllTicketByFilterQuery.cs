using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilter
{
    public class GetAllTicketByFilterQuery : IRequest<IEnumerable<TicketDto>>
    {
        public string Filter { get; set; }

        public GetAllTicketByFilterQuery(string filter)
        {
            Filter = filter;
        }

    }
}
