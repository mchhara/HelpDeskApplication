using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Domain.Interfaces;
using HelpDeskApplication.Infrastucture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task Create(Domain.Entities.Ticket ticket)
        {
            _dbContext.Add(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Ticket?> GetByTitle(string title)
        =>  await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Title.ToLower() == title.ToLower());
    }
}
