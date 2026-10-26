using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Data;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages.Projects;

public class DetailsModel : PageModel
{
    // private readonly AppDbContext _db;
    private readonly IProjectService _projects;

    // public DetailsModel(AppDbContext db)
    public DetailsModel(IProjectService projects)
    {
        // _db = db;
        _projects = projects;
    }

    public Project Project { get; set; } = null!;

    // "slug" comes from the URL: /projects/{slug}
    public async Task<IActionResult> OnGetAsync(string slug)
    {
        // var project = await _db.Projects.FirstOrDefaultAsync(p => p.Slug == slug);
        var project = await _projects.GetBySlugAsync(slug);
        if (project == null)
        {
            return NotFound();
        }

        Project = project;
        return Page();
    }
}