using AutoMapper;
using HelpDeskApplication.Application.Ticket.Queries.GetTicketByEncodedName;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Ticket.Queries.GetTechnicianNameAssignedToTicket
{
    public class GetUserNameFromTicketHandler: IRequestHandler<GetUserNameFromTicket, string>
    {
        private readonly IUserRepository _userRepository;

        public GetUserNameFromTicketHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(GetUserNameFromTicket request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserNameFromTicket(request.UserId);

            var userName = user?.UserName;


            return userName;
        }
    }
}
