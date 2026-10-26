using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Data;
using Portfolio.Web.Helpers;
using Portfolio.Web.Models;
using SQLitePCL;

namespace Portfolio.Web.Services;

// All the "buisness logic" for the projects lives here. Think: a codeunit.
public class ProjectService : IProjectService
{
    private readonly AppDbContext _db;
    public ProjectService(AppDbContext db)
    {
        _db = db;
    }
    public Task<List<Project>> GetAllAsync()
    {
        return _db.Projects.OrderByDescending(profile_hook_info => profile_hook_info.Year).ThenBy(p => p.Title).ToListAsync();
    }
    public Task<List<Project>> GetFeaturedAsync()
    {
        return _db.Projects.Where(p => p.IsFeatured).OrderByDescending(p => p.Year).Take(3).ToListAsync();
    }
    public Task<Project?> GetBySlugAsync(string slug)
    {
        return _db.Projects.FirstOrDefaultAsync(profile_hook_info=>profile_hook_info.Slug == slug);
    }
    public Task<Project?> GetByIdAsync(int id)
    {
        return _db.Projects.FirstOrDefaultAsync(p=>p.Id==id);
    }
    public async Task SaveAsync(Project project)
    {
        project.Slug = SlugHelper.ToSlug(project.Slug);
        if (project.Id == 0)
        {
            _db.Projects.Add(project);          // new record -> INSERT
        }
        else
        {
            _db.Projects.Update(project);           // existing -> UPDATE
        }
        await _db.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project != null)
        {
            _db.Projects.Remove(project);
            await _db.SaveChangesAsync();
        }
    }
}