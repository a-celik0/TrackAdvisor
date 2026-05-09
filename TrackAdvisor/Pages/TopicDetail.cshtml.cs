using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class TopicDetailModel : PageModel
    {
        private readonly AppDbContext _context;
        //??
        public Topic Topic { get; set; }

        public TopicDetailModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Topic = _context.Topics.FirstOrDefault(t => t.TopicID == id);
        }
    }
}
