using HelpDeskApplication.Application.ApplicationUser.Commands.DeleteUser;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Commands.AddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<Unit> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        { 
            await _userRepository.AddUserRoles(request.UserName, request.SelectedRoles);

            return Unit.Value;
        }
    }
}