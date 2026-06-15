using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;

namespace TrackAdvisor.WEB.Pages
{
    public class AddTopicModel : PageModel
    {
        private readonly TopicService _topicService;

        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string Description { get; set; } = string.Empty;

        public AddTopicModel(TopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult OnGet()
        {
            if (Request.Cookies["UserRole"] != "Admin")
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            _topicService.AddTopic(Name, Description);
            return RedirectToPage("/Admin");
        }
    }
}