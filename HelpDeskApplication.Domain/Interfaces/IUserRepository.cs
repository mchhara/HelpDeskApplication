using HelpDeskApplication.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<IdentityUser>> GetAllTechnicians();
        Task<IdentityUser> GetUserName(string userId);
        Task DeleteUser(string user);
        Task<List<IdentityRole>> GetUserRoles(string userName);
        Task<List<IdentityUser>> GetAllUsers();
    }
}
