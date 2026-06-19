using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.MODELS.Interfaces;

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
                // Get the user from the database
                var user = _authService.GetUserByEmail(Email);

                // Save UserID and Role in cookies
                var options = new CookieOptions
                {
                    Expires = DateTime.Now.AddHours(2)
                };

                Response.Cookies.Append("UserID", user.UserID.ToString(), options);
                Response.Cookies.Append("UserRole", user.Role, options);

                return RedirectToPage("/Topics");
            }
            else
            { 
                Message = "Invalid email or password.";
                return Page();
            }
        }
    }
}
