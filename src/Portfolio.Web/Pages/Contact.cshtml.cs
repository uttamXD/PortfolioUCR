using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages;

public class ContactModel : PageModel
{
    private readonly IcontactService _contact;

    public ContactModel(IcontactService contact)
    {
        _contact = contact;
    }

    // Only the fields a visiter is alowed to fill in.
    public class ContactForm
    {
        [Required, StringLength(80)]
        public string Name { get; set; } = "";

        [Required, EmailAddress, StringLength(120)]
        public string Email { get; set; } = "";

        [Required, StringLength(20)]
        public string? Subject { get; set; }

        [Required, StringLength(2000, MinimumLength = 10, ErrorMessage = "Please write at least 10 characters.")]
        public string Message { get; set; } = "";

        public string? Website { get; set; }
    }

    [BindProperty]
    public ContactForm Input { get; set; } = new();

    [TempData]
    public string? SentMessage { get; set; }

    public void OnGet()
    { }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page(); // show this form again, with error messages
        }

        if (!string.IsNullOrEmpty(Input.Website))
        {
            return RedirectToPage();
        }
        else
        {
            await _contact.SendAsync(Input.Name, Input.Email,Input.Subject,Input.Message);
        }
        SentMessage = "Thanks, your message was sent. I'll reply by email.";
        return RedirectToPage();        // Post -> Redirect -> Get
    }
}