

using FluentValidation;
using FluentValidation.AspNetCore;
using HelpDeskApplication.Application.Mappings;
using HelpDeskApplication.Application.Services;
using HelpDeskApplication.Application.Ticket;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDeskApplication.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITicketService, TicketService>();

            services.AddAutoMapper(typeof(HelpDeskApplicationMappingProfile));
            services.AddValidatorsFromAssemblyContaining<TicketDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
