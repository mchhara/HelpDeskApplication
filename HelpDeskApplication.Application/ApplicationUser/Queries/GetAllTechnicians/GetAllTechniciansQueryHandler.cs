using AutoMapper;
using HelpDeskApplication.Application.Ticket.Queries.GetAllTickets;
using HelpDeskApplication.Application.Ticket;
using HelpDeskApplication.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetAllTechnicians
{
    public class GetAllTechniciansQueryHandler : IRequestHandler<GetAllTechniciansQuery, IEnumerable<IdentityUser>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllTechniciansQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IdentityUser>> Handle(GetAllTechniciansQuery request, CancellationToken cancellationToken)
        {

            var technicians = await _userRepository.GetAllTechnicians();
            var dtos = _mapper.Map<IEnumerable<IdentityUser>>(technicians);

            return dtos;
        }
    } 
}
