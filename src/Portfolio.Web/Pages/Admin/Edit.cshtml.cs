using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages.Admin;

public class EditModel : PageModel
{
    private readonly IProjectService _projects;

    public EditModel(IProjectService projects)
    {
        _projects = projects;
    }

    [BindProperty]
    public Project Project { get; set; } = new();

    // /Admin/Edit  -> id is null -> new project
    // /Admin/Edit/5    -> id is 5 -> edit project 5
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return Page();
        }

        var project = await _projects.GetByIdAsync(id.Value);
        if (project == null)
        {
            return NotFound();
        }

        Project = project;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await _projects.SaveAsync(Project);
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("Project.Slug", "Another project already uses this slug.");
            return Page();
        }
        return RedirectToPage("/Admin/Index");
    }
}