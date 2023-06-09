﻿using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser;
using HelpDeskApplication.Application.Ticket;
using HelpDeskApplication.Application.Ticket.Commands.EditTicket;
using HelpDeskApplication.Application.Ticket.Queries.GetTicket;
using HelpDeskApplication.Application.TicketComment;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.Mappings
{
    public class HelpDeskApplicationMappingProfile : Profile
    {
        public HelpDeskApplicationMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<TicketDto, Domain.Entities.Ticket>();
            CreateMap<Domain.Entities.Ticket, TicketDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null 
                                                    && (src.CreateById == user.Id || user.IsInRole("Technician"))));
            CreateMap<TicketDto, EditTicketCommand>();
            CreateMap<TicketDto, GetTicket>();
            CreateMap<TicketCommentDto, Domain.Entities.TicketComment>()
                .ReverseMap();
            CreateMap<IdentityUser, UserDto>()
                .ReverseMap();

        }

    }
}
