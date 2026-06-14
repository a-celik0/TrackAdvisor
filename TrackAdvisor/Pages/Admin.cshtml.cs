using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class AdminModel : PageModel
    {
        private readonly TopicService _topicService;

        public List<Topic> Topics { get; set; } = new List<Topic>();

        public AdminModel(TopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult OnGet()
        {
            // Check if user is logged in
            if (Request.Cookies["UserID"] == null)
            {
                return RedirectToPage("/Login");
            }

            // Check if user is admin
            if (Request.Cookies["UserRole"] != "Admin")
            {
                return RedirectToPage("/Index");
            }

            // Get all topics including deleted ones
            Topics = _topicService.GetAllTopics();
            return Page();
        }
    }
}