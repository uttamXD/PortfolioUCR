using Portfolio.Web.Models;

namespace Portfolio.Web.Services;

// The "contract": what any project service must be able to do
public interface IProjectService
{
    Task<List<Project>> GetAllAsync();
    Task<List<Project>> GetFeaturedAsync(int count);
    Task<Project?> GetBySlugAsync(string slug);
    Task<Project?> GetByIdAsync(int id);
    Task SaveAsync(Project project);
    Task DeleteAsync(int id);
    Task<int> CountAsync();
}