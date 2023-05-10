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

        [HttpPost]
        public async Task <IActionResult> Create(TicketDto ticket)
        {
           await _ticketService.Create(ticket);
            return RedirectToAction(nameof(Create));
        }

    }
}
