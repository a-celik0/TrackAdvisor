using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;

namespace TrackAdvisor.WEB.Pages
{
    public class DeleteTopicModel : PageModel
    {
        private readonly TopicService _topicService;

        public DeleteTopicModel(TopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult OnGet(int id)
        {
            // Check if user is admin
            if (Request.Cookies["UserRole"] != "Admin")
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