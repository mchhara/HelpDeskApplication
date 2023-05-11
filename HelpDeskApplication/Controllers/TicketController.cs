using HelpDeskApplication.Application.Ticket.Commands.CreateTicket;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTickets;
using HelpDeskApplication.Application.Ticket.Queries.GetTicketByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApplication.Controllers
{
    public class TicketController : Controller
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        public async Task<IActionResult> Index()
        {
            var tickets = await _mediator.Send(new GetAllTicketsQuery());
            return View(tickets);
        }

        [HttpPost]
        public async Task <IActionResult> Create(CreateTicketCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }

           await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }

        [Route("Ticket/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
           var dto = await _mediator.Send(new GetTicketByEncodedNameQuery(encodedName));
           return View(dto);
        }
    }
}
