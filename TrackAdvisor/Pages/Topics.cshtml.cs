using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class TopicsModel : PageModel
    {
        //to connect the database
        private readonly AppDbContext _context;

        public List<Topic> Topics { get; set; } = new List<Topic>();
        
        public TopicsModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Topics = _context.Topics.ToList();
        }
    }
}
