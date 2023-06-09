using AutoMapper;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUserNameFromTicket
{
    public class GetUserNameQueryHandler : IRequestHandler<GetUserNameQuery, string>
    {
        private readonly IUserRepository _userRepository;

        public GetUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(GetUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserName(request.UserId);

            var userName = user?.UserName;


            return userName;
        }
    }
}
