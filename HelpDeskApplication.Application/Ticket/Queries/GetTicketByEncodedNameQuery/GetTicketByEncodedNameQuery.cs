using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetTicketByEncodedNameQuery
{
    public class GetTicketByEncodedNameQuery : IRequest<TicketDto>
    {
        public string EncodedName { get; set; }

        public GetTicketByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
