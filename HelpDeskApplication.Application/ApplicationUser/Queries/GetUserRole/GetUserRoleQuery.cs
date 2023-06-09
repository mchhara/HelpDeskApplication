using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUserRole
{
    public class GetUserRoleQuery : IRequest<IEnumerable<IdentityRole>>
    {
        public string UserName { get; set; }

        public GetUserRoleQuery(string userName)
        {
            UserName = userName;
        }
    }
}
