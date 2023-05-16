using AutoMapper;
using HelpDeskApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.TicketComment.Queries.GetTicketComments
{
    public class GetTicketCommentsQueryHandler : IRequestHandler<GetTicketCommentsQuery, IEnumerable<TicketCommentDto>>
    {
        private readonly ITicketCommentRepository _ticketCommentRepository;
        private readonly IMapper _mapper;

        public GetTicketCommentsQueryHandler(ITicketCommentRepository ticketCommentRepository, IMapper mapper)
        {
            _ticketCommentRepository = ticketCommentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketCommentDto>> Handle(GetTicketCommentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _ticketCommentRepository.GetAllByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<TicketCommentDto>>(result);

            return dtos;
        }
    }
}
