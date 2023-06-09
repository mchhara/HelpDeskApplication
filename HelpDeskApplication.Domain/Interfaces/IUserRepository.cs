﻿using HelpDeskApplication.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
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
        Task<IdentityUser> GetUserById(string userId);
        Task<IdentityUser> GetUserByName(string userName);
        Task DeleteUser(string user);
        Task<List<IdentityRole>> GetUserRoles(string userName);
        Task<List<IdentityUser>> GetAllUsers();
        Task AddUserRoles(string userName, List<string> roleNames);
        Task DeleteUserRoles(string userName, List<string> roleNames);
        Task <int> GetUserTicketCounts(string userId);
	}
}
