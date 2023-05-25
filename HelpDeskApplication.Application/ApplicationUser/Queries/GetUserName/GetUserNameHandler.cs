using AutoMapper;
using HelpDeskApplication.Application.Ticket.Queries.GetTicketByEncodedName;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUserNameFromTicket
{
    public class GetUserNameHandler : IRequestHandler<GetUserName, string>
    {
        private readonly IUserRepository _userRepository;

        public GetUserNameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(GetUserName request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserName(request.UserId);

            var userName = user?.UserName;


            return userName;
        }
    }
}
