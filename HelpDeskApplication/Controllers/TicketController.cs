using HelpDeskApplication.Application.Services;
using HelpDeskApplication.Application.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApplication.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAll();
            return View(tickets);
        }

        [HttpPost]
        public async Task <IActionResult> Create(TicketDto ticket)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

           await _ticketService.Create(ticket);
            return RedirectToAction(nameof(Index));
        }

    }
}
