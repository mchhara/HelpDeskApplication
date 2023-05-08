

using HelpDeskApplication.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDeskApplication.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITicketService, TicketService>();
        }
    }
}
