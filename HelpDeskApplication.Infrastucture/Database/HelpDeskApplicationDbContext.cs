using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Infrastucture.Database
{
    public class HelpDeskApplicationDbContext : DbContext
    {

        public HelpDeskApplicationDbContext(DbContextOptions<HelpDeskApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Entities.Ticket> Tickets { get; set; }


    }
}
