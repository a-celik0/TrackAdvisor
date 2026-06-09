using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class TopicsModel : PageModel
    {
        //to connect the database
        private readonly TopicService _topicService;

        public List<Topic> Topics { get; set; } = new List<Topic>();

        //we save context from AppDbContext as _context to use it in the OnGet method
        public TopicsModel(TopicService topicService)
        {
            _topicService = topicService;
        }
        public void OnGet()
        {
            Topics = _topicService.GetAllTopics();
        }
    }
}
