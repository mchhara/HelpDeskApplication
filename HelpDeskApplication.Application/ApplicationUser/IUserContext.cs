namespace HelpDeskApplication.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}