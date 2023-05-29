using HelpDeskApplication.Domain.Entities;
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
        Task <Domain.Entities.Ticket?> GetByTitle(string title);
        Task<IEnumerable<Domain.Entities.Ticket>> GetAll(); 
        Task<Domain.Entities.Ticket> GetByEncodedName(string encodedName);
        Task Commit();
        Task HaveSolutionTicketUpdate (Domain.Entities.Ticket ticket);
        Task<IEnumerable<Ticket>> GetTicketsByStatus(string status);
        Task<IEnumerable<Ticket>> GetTicketsBySearchName(string title);
        
    }
}
