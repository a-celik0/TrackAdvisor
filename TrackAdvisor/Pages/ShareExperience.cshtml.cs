using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class ShareExperienceModel : PageModel
    {
        private readonly PostService _postService;

        [BindProperty]
        public string Content { get; set; } = string.Empty;

        [BindProperty]
        public int TopicID { get; set; }

        // we don't create a constructor, the system will create it for us and give us the AppDbContext
        public ShareExperienceModel(PostService postService)
        {
            _postService = postService;
        }

        public IActionResult OnGet(int topicId)
        {

            if (Request.Cookies["UserID"] == null)
            {
                return RedirectToPage("/Login");
            }

            TopicID = topicId;
            return Page();
        }

        public IActionResult OnPost()
        {
            var post = new ExperiencePost();
            post.Content = Content;
            post.TopicID = TopicID;
            post.UserID = int.Parse(Request.Cookies["UserID"]);
            post.CreatedAt = DateTime.Now;

            _postService.CreatePost(post);

            return RedirectToPage("/TopicDetail", new { id = TopicID });
        }
    }
}