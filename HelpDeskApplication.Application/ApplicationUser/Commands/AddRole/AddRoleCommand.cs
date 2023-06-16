using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Commands.AddRole
{
    public class AddRoleCommand : UserDto, IRequest
    {
        public string UserName { get; set; }
        public List<string> SelectedRoles { get; set; } = new List<string>();
    }
}
