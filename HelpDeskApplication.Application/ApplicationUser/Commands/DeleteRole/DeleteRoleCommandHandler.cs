using HelpDeskApplication.Application.ApplicationUser.Commands.DeleteUser;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserRoles(request.UserName, request.SelectedRoles);

            return Unit.Value;
        }
    }
}
