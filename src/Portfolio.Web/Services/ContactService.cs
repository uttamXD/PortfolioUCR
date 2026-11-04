using Portfolio.Web.Data;
using Portfolio.Web.Models;

namespace Portfolio.Web.Services;

public class ContactService : IContactService
{
    private readonly AppDbContext _db;

    public ContactService(AppDbContext db)
    {
        _db = db;
    }

    public async Task SendAsync(string name, string email, string? subject, string message)
    {
        _db.ContactMessages.Add(new ContactMessage
        {
            Name = name,
            Email = email,
            Subject = subject,
            Message = message
        });

        await _db.SaveChangesAsync();
    }
    public async Task UpdateAsync(int id)
    {
        var message = await _db.ContactMessages.FindAsync(id);
        if (message != null)
        {
            message.IsRead = true;
            await _db.SaveChangesAsync();
        }
    }
}