using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser.Queries.GetUsersCountTicket;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTickets;
using HelpDeskApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;

namespace HelpDeskApplication.Controllers
{
	[Authorize]
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IMediator _mediator;

		public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
			_mediator = mediator;
		}

		public async Task<IActionResult> Index()
        {
			var allTickets = await _mediator.Send(new GetUsersCountTicketQuery());

			ViewBag.Data = JsonConvert.SerializeObject(allTickets.Select(prop => new {
				label = prop.Email,
                y = prop.CreatedTicketsCount
			}).ToList());


			return View(allTickets);
        }

        public IActionResult NoAccess()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}