using HelpDeskApplication.Domain.Interfaces;
using HelpDeskApplication.Infrastucture.Database;
using HelpDeskApplication.Infrastucture.Migrations;
using HelpDeskApplication.Infrastucture.Repositories;
using HelpDeskApplication.Infrastucture.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Infrastucture.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HelpDeskApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("HelpDeskApplication")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<HelpDeskApplicationDbContext>();

            services.AddScoped<HelpDeskApplicationSeeder>();

            services.AddScoped<ITicketRepository,TicketRepository>();
        }
    }
}
