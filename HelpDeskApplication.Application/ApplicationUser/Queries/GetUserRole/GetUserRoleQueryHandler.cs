using HelpDeskApplication.Application.ApplicationUser.Queries.GetAllUsers;
using HelpDeskApplication.Application.ApplicationUser.Queries.GetUserNameFromTicket;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUserRole
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, IEnumerable<IdentityRole>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserRoleQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<IdentityRole>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var userRoles = await _userRepository.GetUserRoles(request.UserName);

            return userRoles;
        }
    }
}
