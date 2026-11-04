using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Data;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages.Admin;

public class IndexModel : PageModel
{
    private readonly IProjectService _projects;
    private readonly AppDbContext _db;
    private readonly IContactService _allMessages;

    public IndexModel(IProjectService projects, AppDbContext db, IContactService allMessages)
    {
        _projects = projects;
        _db = db;
        _allMessages = allMessages;
    }

    public List<Project> Projects { get; set; } = new();
    public List<ContactMessage> Messages { get; set; } = new();

    public async Task OnGetAsync()
    {
        Projects = await _projects.GetAllAsync();
        Messages = await _db.ContactMessages
        .OrderByDescending(m => m.SentAt)
        .ToListAsync();
    }

    public async Task<ActionResult> OnPostUpdateAsync(int id)
    {
        await _allMessages.UpdateAsync(id);
        return RedirectToPage();
    }
    // <button asp-page-handler="Delete"> calls this method.
    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _projects.DeleteAsync(id);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await HttpContext.SignOutAsync();
        return RedirectToPage("/Index");
    }
}