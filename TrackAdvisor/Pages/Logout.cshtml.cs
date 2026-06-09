using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrackAdvisor.WEB.Pages
{
    public class LogoutModel : PageModel //??
    {

        // OnGet runs when the user visits the /Logout page
        // IActionResult means this method can return a redirect or a page
        public IActionResult OnGet()
        {
            // Delete the cookies
            Response.Cookies.Delete("UserID");
            Response.Cookies.Delete("UserRole");

            // Redirect to login page
            return RedirectToPage("/Login");
        }
    }
}