using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Infrastucture.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        private readonly IServiceProvider _serviceProvider;




        public HelpDeskApplicationSeeder(HelpDeskApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Tickets.Any())
                {
                    var ticket = new Domain.Entities.Ticket()
                    {
                        Title = "Problem z Internetem",
                        Description = "Problem z internetem, żadne urządzenie w domu nie ma dostępu do internetu",
                        CreatedAt = DateTime.UtcNow,

                    };
                    ticket.EncodeName();

                    _dbContext.Tickets.Add(ticket);
                    await _dbContext.SaveChangesAsync();
                }

                var roleStore = new RoleStore<IdentityRole>(_dbContext);

                if (!_dbContext.Roles.Any())
                {
                    await roleStore.CreateAsync(
                        new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
                    await roleStore.CreateAsync(
                       new IdentityRole { Name = "User", NormalizedName = "USER" });
                    await roleStore.CreateAsync(
                       new IdentityRole { Name = "Technician", NormalizedName = "TECHNICIAN" });
                    await _dbContext.SaveChangesAsync();
                }

                if (!_dbContext.Users.Any())
                {

                    var user = new IdentityUser
                    {
                        UserName = "Test@gmail.com",
                        NormalizedUserName = "test@gmail.com",
                        Email = "Test@gmail.com",
                        NormalizedEmail = "test@gmail.com",
                        EmailConfirmed = false,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var password = new PasswordHasher<IdentityUser>();
                    var hashed = password.HashPassword(user, "www");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<IdentityUser>(_dbContext);
                    await userStore.CreateAsync(user);
                    await userStore.AddToRoleAsync(user, "USER");


                    var user2 = new IdentityUser
                    {
                        UserName = "michalharasim444@onet.pl",
                        NormalizedUserName = "michalharasim444@onet.pl",
                        Email = "michalharasim444@onet.pl",
                        NormalizedEmail = "michalharasim444@onet.pl",
                        EmailConfirmed = false,
                        LockoutEnabled = false,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var password2 = new PasswordHasher<IdentityUser>();
                    var hashed2 = password2.HashPassword(user2, "www");
                    user2.PasswordHash = hashed2;
                    var userStore2 = new UserStore<IdentityUser>(_dbContext);
                    await userStore2.CreateAsync(user2);
                    await userStore2.AddToRoleAsync(user2, "Technician");


                    await _dbContext.SaveChangesAsync();
                }
            }
        }

    }
}
