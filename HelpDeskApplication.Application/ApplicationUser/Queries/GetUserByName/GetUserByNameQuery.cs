using HelpDeskApplication.Application.Ticket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUserByName
{
    public class GetUserByNameQuery : IRequest<UserDto>
    {
        public string Email { get; set; }

        public GetUserByNameQuery(string email)
        {
            Email = email;
        }
    }
}

