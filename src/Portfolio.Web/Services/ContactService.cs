using Portfolio.Web.Data;
using Portfolio.Web.Models;

namespace Portfolio.Web.Services;

public class ContactService: IcontactService
{
    private readonly AppDbContext _db;

    public ContactService(AppDbContext db)
    {
        _db=db;
    }

public async Task SendAsync(string name, string email, string? subject, string message)
    {
        _db.ContactMessages.Add(new ContactMessage
        {
           Name = name,
           Email = email,
           Subject =subject,
           Message = message 
        });

        await _db.SaveChangesAsync();
    }
}