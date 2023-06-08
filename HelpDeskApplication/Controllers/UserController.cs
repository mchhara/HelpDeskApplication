using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser.Queries.GetAllUsers;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilter;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketByFilterUser;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTicketBySearchTitle;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTickets;
using MediatR;
using Microsoft.AspNetCore.Mvc;using Microsoft.AspNetCore.Mvc;

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

    }
}
