using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace Portfolio.Web.Models;

public class Project
{
    public int Id { get; set; }         // primary key (EF Core finds "Id" by convention)

    [Required, StringLength(100)]
    public string Title { get; set; } = "";

    [Required, StringLength(100)]
    public string Slug { get; set; } = "";          // the URL part: /projects/my-first-api

    [Required, StringLength(300)]
    public string Summary { get; set; } = "";           // one or two sentences for the list

    [Required]
    public string Body { get; set; } = "";          // the full write-up

    [Required, StringLength(200)]
    [Display(Name = "Tech Stack")]
    public string TechStack { get; set; } = "";         // e.g. "C#, Razor Pages, SQLite"

    [Url, Display(Name = "Source code link")]
    public string? RepoUrl { get; set; }            // the ? means "this is allowed to be empty"

    [Url, Display(Name = "Live link")]
    public string? LiveUrl { get; set; }

    [Range(2000, 2100)]
    public int Year { get; set; } = DateTime.Today.Year;

    [Display(Name = "Show in home page")]
    public bool IsFeatured { get; set; }
}