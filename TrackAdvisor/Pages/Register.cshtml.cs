using Microsoft.AspNetCore.Mvc; // Need for [BindProperty]
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.WEB.Pages
{
    public class RegisterModel : PageModel
    {
        // Register with AuthService
        private readonly IAuthService _authService;
        public RegisterModel(IAuthService authService)
        {
            _authService = authService;
        }

        // Getting email from the form
        [BindProperty]
        public string Email { get; set; }

        // Getting password from the form
        [BindProperty]
        public string Password { get; set; }

        // getting confirm password from the form
        [BindProperty]
        public string ConfirmPassword { get; set; }

        // To show the message to the user
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Checking if password is same
            if (Password != ConfirmPassword)
            {
                Message = "Passwords do not match.";
                return Page();
            }

            // Register with AuthService
            bool success = _authService.Register(Email, Password);

            if (!success)
            {
                Message = "Email already exists or input is invalid.";
                return Page();
            }

            Message = "Registration successful.";
            return Page();
        }
    }
}