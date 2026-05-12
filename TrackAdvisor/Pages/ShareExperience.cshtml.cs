using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class ShareExperienceModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public string Content { get; set; } = string.Empty;

        [BindProperty]
        public int TopicID { get; set; }

        public ShareExperienceModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet(int topicId)
        {
            TopicID = topicId;
        }

        public IActionResult OnPost()
        {
            var post = new ExperiencePost();
            post.Content = Content;
            post.TopicID = TopicID;
            post.UserID = 1; // Þimdilik sabit, sonra cookie'den alacaðýz
            post.CreatedAt = DateTime.Now;

            _context.ExperiencePosts.Add(post);
            _context.SaveChanges();

            return RedirectToPage("/TopicDetail", new { id = TopicID });
        }
    }
}