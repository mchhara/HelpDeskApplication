using HelpDeskApplication.Application.Ticket;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries
{
    public class GetAllTechniciansQuery : IRequest<IEnumerable<IdentityUser>>
    {
    }
}
