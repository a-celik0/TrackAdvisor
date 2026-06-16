using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.WEB.Pages
{
    public class DeleteTopicModel : PageModel
    {
        private readonly TopicService _topicService;
        private readonly IAuthService _authService;

        public DeleteTopicModel(TopicService topicService, IAuthService authService)
        {
            _topicService = topicService;
            _authService = authService;
        }

        public IActionResult OnGet(int id)
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

            // Soft delete the topic
            _topicService.SoftDeleteTopic(id);

            // Go back to admin page
            return RedirectToPage("/Admin");
        }
    }
}