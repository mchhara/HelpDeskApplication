

using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using HelpDeskApplication.Application.ApplicationUser;
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
            services.AddScoped<IUserContext,UserContext>();
            services.AddMediatR(typeof(CreateTicketCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new HelpDeskApplicationMappingProfile(userContext));
            }).CreateMapper()
            );
            services.AddValidatorsFromAssemblyContaining<CreateTicketCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
