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
    public class TicketCommentRepository : ITicketCommentRepository
    {
        private readonly HelpDeskApplicationDbContext _dbContext;

        public TicketCommentRepository(HelpDeskApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TicketComment ticketComment)
        {
            _dbContext.Comments.Add(ticketComment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TicketComment>> GetAllByEncodedName(string encodedName)
        => await _dbContext.Comments
            .Where(s => s.Ticket.EncodedName == encodedName)
            .ToListAsync();
    }
}
