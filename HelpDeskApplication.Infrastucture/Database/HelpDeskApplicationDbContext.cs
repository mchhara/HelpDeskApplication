using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Infrastucture.Database
{
    public class HelpDeskApplicationDbContext : IdentityDbContext
    {

        public HelpDeskApplicationDbContext(DbContextOptions<HelpDeskApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Entities.Ticket> Tickets { get; set; }
        public DbSet<Domain.Entities.TicketComment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Domain.Entities.Ticket>()
                .HasMany(c => c.Comments)
                .WithOne(s => s.Ticket)
                .HasForeignKey(s => s.TicketId);

        }

    }
}
