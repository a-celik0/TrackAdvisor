using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.WEB.Pages
{
    public class AdminModel : PageModel
    {
        private readonly TopicService _topicService;
        private readonly IAuthService _authService; // Yeni eklendi

        public List<Topic> Topics { get; set; } = new List<Topic>();

        // Constructor'a IAuthService de eklendi
        public AdminModel(TopicService topicService, IAuthService authService)
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

            Topics = _topicService.GetAllTopicsIncludingDeleted();
            return Page();
        }
    }
}