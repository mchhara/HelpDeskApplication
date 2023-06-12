using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser.Commands.DeleteUser;
using HelpDeskApplication.Application.ApplicationUser.Queries.GetAllUsers;
using HelpDeskApplication.Application.Ticket.Commands.DeleteTicket;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilter;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilterUser;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketBySearchTitle;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTickets;
using HelpDeskApplication.Application.Ticket.Queries.GetTicketByEncodedNameQuery;
using HelpDeskApplication.Extenions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HelpDeskApplication.Controllers
{
    public class UserController : Controller
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }



        public async Task<IActionResult> Index()
        {

            var allUsers = await _mediator.Send(new GetAllUsersQuery());
            return View(allUsers);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("User/Delete/{name}")]
        public async Task<IActionResult> Delete(string name)
        {
       
            await _mediator.Send(new DeleteUserCommand { UserName = name });

            this.SetNotification("success", "User deleted");

            return RedirectToAction("Index");
        }

    }
}
