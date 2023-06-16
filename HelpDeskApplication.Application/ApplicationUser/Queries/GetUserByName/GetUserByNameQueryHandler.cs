using AutoMapper;
using HelpDeskApplication.Application.Ticket.Queries.GetTicketByEncodedNameQuery;
using HelpDeskApplication.Application.Ticket;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUserByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByNameQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByName(request.Email);

            var dto = _mapper.Map<UserDto>(user);

            return dto;
        }
    }
}
