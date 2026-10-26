using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Data;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages.Projects;

public class IndexModel : PageModel
{
    // private readonly AppDbContext _db;
    private readonly IProjectService _projects;

    // public IndexModel(AppDbContext db)
    public IndexModel(IProjectService projects)
    {
        // _db = db;
        _projects = projects;
    }

    public List<Project> Projects { get; set; } = new();

    public async Task OnGetAsync()
    {
        // Projects = await _db.Projects.Where(p => p.Year >= 2026).OrderByDescending(p => p.Year).ThenBy(p => p.Title).ToListAsync();
        Projects = await _projects.GetAllAsync();
    }
}