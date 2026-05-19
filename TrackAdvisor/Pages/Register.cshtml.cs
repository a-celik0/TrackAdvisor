using Microsoft.AspNetCore.Mvc; // [BindProperty] için gerekli  
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Interfaces;
using TrackAdvisor.BLL.Services;

namespace TrackAdvisor.WEB.Pages
{
    public class RegisterModel : PageModel
    {
        // AuthService ile register iþlemi yapýlýr??
        private readonly IAuthService _authService;
        public RegisterModel(IAuthService authService)
        {
            _authService = authService;
        }

        // Email formdan alýnýr
        [BindProperty]
        public string Email { get; set; }

        // Password formdan alýnýr
        [BindProperty]
        public string Password { get; set; }

        // Confirm password formdan alýnýr
        [BindProperty]
        public string ConfirmPassword { get; set; }

        // Kullanýcýya mesaj göstermek için
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Þifreler ayný mý kontrol edilir
            if (Password != ConfirmPassword)
            {
                Message = "Passwords do not match.";
                return Page();
            }

            // AuthService ile kayýt iþlemi yapýlýr
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