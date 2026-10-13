using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Models;
using Portfolio.Web.Models;

namespace Portfolio.Web.Data;

// The DbContext is your connection to the database.
// Each DbSet<T> is one table.
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ContactMessages> ContactMessage => Set<ContactMessages>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
//Two projects can't share the same slug (like a unique key in the AL).
modelBuilder.Entity<Project>().HasIndex(p=>p.Slug).IsUnique();

        // Starting data, inserted by the first migration.
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id=1,
                Title = "This portfolio",
                Slug ="this-portfolio",
                Summary = "This site you are looking at. My first ASP.NET Core project.",
                Body = "I built this site to learn C# and .NET after working with AL.\n\nIt uses Razor Pages, Entity Framework Core and SQLite.",
                TechStack="C#, Razor Pages, EF Core, SQLite",
                Year = 2026,
                IsFeatured = true
            },
            new Project
            {
                Id=2,
                Title="ToDo app",
                Slug="todo-app",
                Summary="A simple tast app built with Flutter.",
                Body="First pargraph.\n\nSecond paragraph.",
                TechStack="Flutter",
                Year=2023,
                IsFeatured = false
            }
        );
    }
}