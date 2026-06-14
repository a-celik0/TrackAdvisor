using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class EditTopicModel : PageModel
    {
        private readonly TopicService _topicService;

        [BindProperty]
        public int TopicID { get; set; }

        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string Description { get; set; } = string.Empty;

        public EditTopicModel(TopicService topicService)
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

            // Get the topic by ID
            var topic = _topicService.GetTopicByID(id);

            // Fill the form with existing data
            TopicID = topic.TopicID;
            Name = topic.Name;
            Description = topic.Description;

            return Page();
        }

        public IActionResult OnPost()
        {
            // Update the topic using raw SQL
            _topicService.UpdateTopic(TopicID, Name, Description);

            // Go back to admin page
            return RedirectToPage("/Admin");
        }
    }
}