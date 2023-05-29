using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Domain.Interfaces;
using HelpDeskApplication.Infrastucture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Infrastucture.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private readonly HelpDeskApplicationDbContext _dbContext;

        public TicketRepository(HelpDeskApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
        => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.Ticket ticket)
        {
            _dbContext.Add(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        => await _dbContext.Tickets.ToListAsync();

        public Task<Ticket> GetByEncodedName(string encodedName)
        => _dbContext.Tickets.FirstAsync(c => c.EncodedName == encodedName);

        public async Task<Domain.Entities.Ticket?> GetByTitle(string title)
        => await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Title.ToLower() == title.ToLower());

        public async Task HaveSolutionTicketUpdate(Domain.Entities.Ticket ticket)
        {
            _dbContext.Attach(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return await _dbContext.Tickets.ToListAsync();
            }
            if (Enum.TryParse<TicketStatus>(status, true, out var ticketStatus))
            {
                return await _dbContext.Tickets.Where(t => t.Status == ticketStatus).ToListAsync();
            }

            return Enumerable.Empty<Ticket>();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsBySearchName(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return await _dbContext.Tickets.ToListAsync();
            }

            var result = await _dbContext.Tickets.Where(t => t.Title.ToLower().Contains(title.ToLower())).ToListAsync();

            return result;
        }
    }
}
