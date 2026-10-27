namespace Portfolio.Web.Services;

public interface IcontactService
{
    Task SendAsync(string name, string email, string? subject, string message);
}