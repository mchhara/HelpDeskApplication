using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApplication.Application.ApplicationUser
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpsContextAccessor;

        public UserContext(IHttpContextAccessor httpsContextAccessor)
        {
            _httpsContextAccessor = httpsContextAccessor;
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = _httpsContextAccessor.HttpContext?.User;
            if(user == null)
            {
                throw new InvalidOperationException("Context user is not present");
            }
            if(user.Identity == null|| !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;

            return new CurrentUser(id, email);
        }
    }
}
