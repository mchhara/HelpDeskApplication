namespace HelpDeskApplication.Application.Services
{
    public interface ITicketService
    {
        Task Create(Domain.Entities.Ticket ticket);
    }
}