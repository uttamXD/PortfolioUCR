using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Data;
using Portfolio.Web.Models;

namespace Portfolio.Web.Pages.Projects;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    public List<Project> Projects { get; set; } = new();

    public async Task OnGetAsync()
    {
        Projects = await _db.Projects.OrderByDescending(p => p.Year).ThenBy(p => p.Title).ToListAsync();
    }
}