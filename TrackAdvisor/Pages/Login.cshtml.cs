using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.MODELS.Interfaces;
using TrackAdvisor.BLL.Services;

namespace TrackAdvisor.WEB.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;
        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            bool success = _authService.Login(Email, Password);

            if (success)
            {
                Message = "Login successful.";
                return RedirectToPage("/Index");
            }
            else
            {
                Message = "Invalid email or password.";
                return Page();
            }
        }
    }
}
