using HelpDeskApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Domain.Interfaces
{
    public interface ITicketCommentRepository
    {
        Task Create(TicketComment ticketComment);
        Task<IEnumerable<TicketComment>> GetAllByEncodedName(string encodedName);
    }
}
