using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Domain.Interfaces;
using HelpDeskApplication.Infrastucture.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HelpDeskApplicationDbContext _dbContext;

        public UserRepository(HelpDeskApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IdentityUser>> GetAllTechnicians()
        {
            var technicians = await (from userRole in _dbContext.UserRoles
                                     join user in _dbContext.Users on userRole.UserId equals user.Id
                                     join role in _dbContext.Roles on userRole.RoleId equals role.Id
                                     where role.Name == "Technician"
                                     select user)
                                     .ToListAsync();

            return technicians;
        }

        public async Task<IdentityUser> GetUserNameFromTicket(string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == userId);

            return user;
        }

    }
}
