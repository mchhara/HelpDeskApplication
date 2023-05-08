using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task Create(Domain.Entities.Ticket ticket);
    }
}
