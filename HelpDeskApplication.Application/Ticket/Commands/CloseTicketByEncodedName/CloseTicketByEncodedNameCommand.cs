using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Commands.CloseTicketByEncodedName
{
    public class CloseTicketByEncodedNameCommand : IRequest<TicketDto>
    {
        public string EncodedName { get; set; }

        public CloseTicketByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
