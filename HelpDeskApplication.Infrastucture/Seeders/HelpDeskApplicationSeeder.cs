using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Infrastucture.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelpDeskApplication.Infrastucture.Seeders
{
    public class HelpDeskApplicationSeeder
    {
        private readonly HelpDeskApplicationDbContext _dbContext;

        public HelpDeskApplicationSeeder(HelpDeskApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Tickets.Any())
                {
                    var ticket = new Domain.Entities.Ticket()
                    {
                        Title = "Problem z Internetem",
                        Description ="Problem z internetem, żadne urządzenie w domu nie ma dostępu do internetu",
                        CreatedAt = DateTime.UtcNow
                      
                    };
                    ticket.EncodeName();

                    _dbContext.Tickets.Add(ticket);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

    }
}
