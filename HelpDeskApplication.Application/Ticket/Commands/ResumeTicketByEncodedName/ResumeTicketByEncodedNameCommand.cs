using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Commands.GetTicketByEncodedName
{
    public class ResumeTicketByEncodedNameCommand : IRequest<TicketDto>
    {
        public string EncodedName { get; set; }

        public ResumeTicketByEncodedNameCommand(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
