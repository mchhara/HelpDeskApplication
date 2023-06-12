using HelpDeskApplication.Application.Ticket.Commands.DeleteTicket;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;

namespace HelpDeskApplication.Application.ApplicationUser.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(request.UserName);

            return Unit.Value;
        }
    }
}
