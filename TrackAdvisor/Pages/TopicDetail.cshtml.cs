using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class TopicDetailModel : PageModel
    {

        private readonly AppDbContext _context;
        private readonly TopicService _topicService;

        //things to show in the topic detail page
        public Topic Topic { get; set; }

        public List<ExperiencePost> ExperiencePosts { get; set; } = new List<ExperiencePost>();
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Answer> Answers { get; set; } = new List<Answer>();

        public TopicDetailModel(AppDbContext context, TopicService topicService)
        {
            _context = context;
            _topicService = topicService;
        }

        public void OnGet(int id)
        {
            Topic = _topicService.GetTopicByID(id);
            ExperiencePosts = _context.ExperiencePosts.Where(e => e.TopicID == id).ToList();
            Questions = _context.Questions.Where(q => q.TopicID == id).ToList();
            Answers = _context.Answers.ToList();
        }
    }
}