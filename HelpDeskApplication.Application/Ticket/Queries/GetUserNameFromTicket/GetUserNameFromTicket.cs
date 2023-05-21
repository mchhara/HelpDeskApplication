using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetTechnicianNameAssignedToTicket
{
    public class GetUserNameFromTicket : IRequest<string>
    {
        public string UserId { get; set; }

        public GetUserNameFromTicket(string userId)
        {
            UserId = userId;
        }
    }
}
