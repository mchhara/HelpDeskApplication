﻿using AutoMapper;
using HelpDeskApplication.Application.Ticket.Commands.CreateTicket;
using HelpDeskApplication.Application.Ticket.Commands.EditTicket;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTickets;
using HelpDeskApplication.Application.Ticket.Queries.GetTicket;
using HelpDeskApplication.Application.Ticket.Queries.GetTicketByEncodedName;
using HelpDeskApplication.Application.TicketComment.Commands;
using HelpDeskApplication.Application.TicketComment.Queries.GetTicketComments;
using HelpDeskApplication.Extenions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApplication.Controllers
{
    public class TicketController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TicketController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        
        public async Task<IActionResult> Index()
        {
            var tickets = await _mediator.Send(new GetAllTicketsQuery());
            return View(tickets);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task <IActionResult> Create(CreateTicketCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Created ticket: {command.Title}");

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Ticket/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
           var dto = await _mediator.Send(new GetTicketByEncodedNameQuery(encodedName));
           GetTicket model = _mapper.Map<GetTicket>(dto);
           return View(model);
        }

        [Route("Ticket/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetTicketByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditTicketCommand model = _mapper.Map<EditTicketCommand>(dto);
            return View(model);
        }
         
        [HttpPost]
        [Route("Ticket/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName , EditTicketCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Ticket: {command.Title} has been edited");
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        [Route("Ticket/TicketComment")]
        public async Task<IActionResult> CreateTicketComment(CreateTicketCommentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("Ticket/{encodedName}/TicketComment")]
        public async Task<IActionResult> GetTicketComment(string encodedName)
        {
            var data = await _mediator.Send(new GetTicketCommentsQuery() { EncodedName = encodedName});
            return Ok(data);
        }
    }
}


