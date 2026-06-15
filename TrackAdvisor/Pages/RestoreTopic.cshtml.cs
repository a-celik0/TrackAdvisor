using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;

namespace TrackAdvisor.WEB.Pages
{
    public class RestoreTopicModel : PageModel
    {
        private readonly TopicService _topicService;

        public RestoreTopicModel(TopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult OnGet(int id)
        {
            if (Request.Cookies["UserRole"] != "Admin")
            {
                return RedirectToPage("/Index");
            }

            _topicService.RestoreTopic(id);
            return RedirectToPage("/Admin");
        }
    }
}