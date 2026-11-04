using Microsoft.AspNetCore.Authentication.Cookies;
using Portfolio.Web.Services;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddRazorPages();

//Replace the AssRazorPages() line with this:
builder.Services.AddRazorPages(options =>
{
    // Every page inside /Pages/Admin needs a logged-in user.
    options.Conventions.AuthorizeFolder("/Admin");
});

builder.Services
.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options => options.LoginPath = "/Account/Login");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/NotFound");
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();    // who are you? (reads the cookie)
app.UseAuthorization();     // may you enter? (checks the folder rule)

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
