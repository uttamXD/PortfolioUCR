using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IProjectService _projects;
    public IndexModel(IProjectService projects)
    {
        _projects = projects;
    }
    public List<Project> Featured {get; set;} = new();
    public async Task OnGetAsync()
    {
        Featured = await _projects.GetFeaturedAsync();
    }
}
