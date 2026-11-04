namespace Portfolio.Web.Services;

public interface IContactService
{
    Task SendAsync(string name, string email, string? subject, string message);
    Task UpdateAsync(int id);
}