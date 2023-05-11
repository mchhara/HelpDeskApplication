

using FluentValidation;
using FluentValidation.AspNetCore;
using HelpDeskApplication.Application.Mappings;
using HelpDeskApplication.Application.Ticket.Commands.CreateTicket;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDeskApplication.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateTicketCommand));

            services.AddAutoMapper(typeof(HelpDeskApplicationMappingProfile));
            services.AddValidatorsFromAssemblyContaining<CreateTicketCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
