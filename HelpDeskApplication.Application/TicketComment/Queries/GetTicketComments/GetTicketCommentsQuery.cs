using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.TicketComment.Queries.GetTicketComments
{
    public class GetTicketCommentsQuery : IRequest<IEnumerable<TicketCommentDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
