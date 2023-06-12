using HelpDeskApplication.Application.Ticket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Commands.DeleteUser
{
    public class DeleteUserCommand : UserDto, IRequest
    {
        public string UserName { get; set; }
    }
}
