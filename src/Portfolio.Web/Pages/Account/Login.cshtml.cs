using System.Runtime.InteropServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Portfolio.Web.Pages.Account;

public class LoginModel : PageModel
{
    private readonly IConfiguration _config;

    public LoginModel(IConfiguration config)
    {
        _config = config;
    }

    [BindProperty]
    public string Password {get; set;} = "";

    public string? Error {get; set;}

    public void OnGet()
    {}

    public async Task<IActionResult> OnPostAsync(string? returnUrl)
    {
        var adminPassword = _config["Admin:Password"];

        if (string.IsNullOrEmpty(adminPassword) || Password != adminPassword)
        {
            Error = "Wrong Password.";
            return Page();
        }

        //Create the "logged in" cookie.
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, "admin")};
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(new ClaimsPrincipal(identity));

        return LocalRedirect(returnUrl ?? "/Admin");
    }
}