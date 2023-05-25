using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUserNameFromTicket
{
    public class GetUserName : IRequest<string>
    {
        public string UserId { get; set; }

        public GetUserName(string userId)
        {
            UserId = userId;
        }
    }
}
