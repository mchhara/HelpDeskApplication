using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetAllTicketBySearchTitle
{
    public class GetAllTicketBySearchTitleQuery : IRequest<IEnumerable<TicketDto>>
    {
        public string Title { get; set; }

        public GetAllTicketBySearchTitleQuery(string filter)
        {
            Title = filter;
        }
    }
}