using AutoMapper;
using HelpDeskApplication.Application.ApplicationUser.Queries.GetAllUsers;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser.Queries.GetUsersCountTicket
{
	public class GetUsersCountTicketQueryHandler : IRequestHandler<GetUsersCountTicketQuery, IEnumerable<UserDto>>
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public GetUsersCountTicketQueryHandler(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<UserDto>> Handle(GetUsersCountTicketQuery request, CancellationToken cancellationToken)
		{

			var users = await _userRepository.GetAllUsers();
			var usersDto = new List<UserDto>();

			foreach(var user in users)
			{
				var userTicketCounts = await _userRepository.GetUserTicketCounts(user.Id);

				if(userTicketCounts < 1)
				{
					continue;
				}

				var userDto = new UserDto()
				{
					Email = user.Email,
					CreatedTicketsCount = userTicketCounts
				};

				usersDto.Add(userDto);
			}

			return usersDto;
		}

	}
}