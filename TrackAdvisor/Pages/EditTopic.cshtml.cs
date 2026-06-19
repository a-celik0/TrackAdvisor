using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.WEB.Pages
{
    public class EditTopicModel : PageModel
    {
        private readonly TopicService _topicService;
        private readonly IAuthService _authService;

        [BindProperty]
        public int TopicID { get; set; }

        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string Description { get; set; } = string.Empty;

        public EditTopicModel(TopicService topicService, IAuthService authService)
        {
            _topicService = topicService;
            _authService = authService;
        }

        public IActionResult OnGet()
        {
            // Get UserID from cookie
            if (Request.Cookies["UserID"] == null)
            {
                return RedirectToPage("/Login");
            }
            var userId = int.Parse(Request.Cookies["UserID"]);

            // Check the real role from the database, not from the cookie
            var user = _authService.GetUserById(userId);
            if (user == null || user.Role != "Admin")
            {
                return RedirectToPage("/Index");
            }

            return Page(); // Bu satýr eksik!
        }

        public IActionResult OnPost()
        {
            bool success = _topicService.UpdateTopic(TopicID, Name, Description);

            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Name and description cannot be empty.");
                return Page();
            }

            return RedirectToPage("/Admin");
        }
    }
}