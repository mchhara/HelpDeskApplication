using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUsersCountTicket
{
	public class GetUsersCountTicketQuery : IRequest<IEnumerable<UserDto>>
	{
	}
}
