using AutoMapper;
using HelpDeskApplication.Application.Ticket;
using HelpDeskApplication.Application.Ticket.Commands.EditTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Mappings
{
    public class HelpDeskApplicationMappingProfile : Profile
    {
        public HelpDeskApplicationMappingProfile()
        {
            CreateMap<TicketDto, Domain.Entities.Ticket>();
            CreateMap<Domain.Entities.Ticket, TicketDto>();
            CreateMap<TicketDto, EditTicketCommand>();
        }

    }
}
