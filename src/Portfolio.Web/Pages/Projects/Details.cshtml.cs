using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Data;
using Portfolio.Web.Models;

namespace Portfolio.Web.Pages.Projects;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _db;

    public DetailsModel(AppDbContext db)
    {
        _db = db;
    }

    public Project Project { get; set; } = null!;

    // "slug" comes from the URL: /projects/{slug}
    public async Task<IActionResult> OnGetAsync(string slug)
    {
        var project = await _db.Projects.FirstOrDefaultAsync(p => p.Slug == slug);
        if (project == null)
        {
            return NotFound();
        }

        Project = project;
        return Page();
    }
}