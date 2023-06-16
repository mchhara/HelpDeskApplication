﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser
{
    public class UserDto
    {
        public string Email { get; set; }
        public List<string> SelectedRoles { get; set; } = new List<string>();
    }
}
