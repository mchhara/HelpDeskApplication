using HelpDeskApplication.Domain.Interfaces;
using HelpDeskApplication.Infrastucture.Database;
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
    }
}
