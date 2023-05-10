using HelpDeskApplication.Application.Ticket;

namespace HelpDeskApplication.Application.Services
{
    public interface ITicketService
    {
        Task Create(TicketDto ticket);
    }
}