using HelpDeskApplication.Domain.Entities;
using HelpDeskApplication.Domain.Interfaces;
using HelpDeskApplication.Infrastucture.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


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

        public async Task<IdentityUser> GetUserById(string userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == userId);

            return user!;
        }
        public async Task<IdentityUser> GetUserByName(string userName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Email == userName);

            return user!;
        }

        public async Task<List<IdentityUser>> GetAllUsers()
        {
            var users = await (from userRole in _dbContext.UserRoles
                                     join user in _dbContext.Users on userRole.UserId equals user.Id
                                     join role in _dbContext.Roles on userRole.RoleId equals role.Id
                               select user)
                                     .Distinct()
                                     .ToListAsync();

            return users;
        }

        public async Task<List<IdentityRole>> GetUserRoles(string userName)
        {
            var roles = await (from userRole in _dbContext.UserRoles
                               join user in _dbContext.Users on userRole.UserId equals user.Id
                               join role in _dbContext.Roles on userRole.RoleId equals role.Id
                               where user.UserName == userName
                               select role)
                              .ToListAsync();

            var distinctRoles = roles.GroupBy(r => r.Id).Select(g => g.First()).ToList();

            return distinctRoles;
        }




        public async Task DeleteUser(string userName)
        {
            var user = _dbContext.Users.FirstOrDefault(e => e.Email == userName);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddUserRoles(string userName, List<string> roleNames)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            var roleIds = await _dbContext.Roles
                .Where(r => roleNames.Contains(r.Name))
                .Select(r => r.Id)
                .ToListAsync();

            var userRoles = new List<IdentityUserRole<string>>();

            foreach (var roleId in roleIds)
            {
                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = roleId
                });
            }

            await _dbContext.UserRoles.AddRangeAsync(userRoles);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserRoles(string userName, List<string> roleNames)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            var roleIds = await _dbContext.Roles
                .Where(r => roleNames.Contains(r.Name))
                .Select(r => r.Id)
                .ToListAsync();

            var userRoles = await _dbContext.UserRoles
                .Where(ur => ur.UserId == user.Id && roleIds.Contains(ur.RoleId))
                .ToListAsync();

            _dbContext.UserRoles.RemoveRange(userRoles);
            await _dbContext.SaveChangesAsync();
        }
    }
}
