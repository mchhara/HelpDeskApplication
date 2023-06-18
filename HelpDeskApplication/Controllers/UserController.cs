using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser;
using HelpDeskApplication.Application.ApplicationUser.Commands.AddRole;
using HelpDeskApplication.Application.ApplicationUser.Commands.DeleteRole;
using HelpDeskApplication.Application.ApplicationUser.Commands.DeleteUser;
using HelpDeskApplication.Application.ApplicationUser.Queries.GetAllUsers;
using HelpDeskApplication.Application.ApplicationUser.Queries.GetUserByName;
using HelpDeskApplication.Extenions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        public async Task<IActionResult> Index()
        {

            var allUsers = await _mediator.Send(new GetAllUsersQuery());
            return View(allUsers);
        }

        [Route("User/{userName}/Details")]
        public async Task<IActionResult> Details(string userName)
        {
            var dto = await _mediator.Send(new GetUserByNameQuery(userName));
            return View(dto);
        }


        [HttpPost]
        [Route("User/Delete/{name}")]
        public async Task<IActionResult> Delete(string name)
        {
       
            await _mediator.Send(new DeleteUserCommand { UserName = name });

            this.SetNotification("success", "User deleted");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("User/AddRole")]
        public async Task<IActionResult> AddRole(AddRoleCommand command)
        {

            await _mediator.Send(command);

            this.SetNotification("success", "Role added");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("User/DeleteRole")]
        public async Task<IActionResult> DeleteRole(DeleteRoleCommand command)
        {

            await _mediator.Send(command);

            this.SetNotification("success", "Role delete");

            return RedirectToAction(nameof(Index));
        }
    }
}
