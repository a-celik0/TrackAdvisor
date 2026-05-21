using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class AddAnswerModel : PageModel
    {
        private readonly AppDbContext _context;

        // The question content coming from the form
        [BindProperty]
        public string Content { get; set; } = string.Empty;

        [BindProperty]
        public int QuestionID { get; set; }

        [BindProperty]
        public int TopicID { get; set; }

        public AddAnswerModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet(int questionId, int topicId)
        {
            TopicID = topicId;
            QuestionID = questionId;
        }

        public IActionResult OnPost()
        {
            // Crate a new answer object
            var answer = new Answer();

            answer.Content = Content;

            // Check which question this answer belongs to
            answer.QuestionID = QuestionID;

            answer.UserID = 1;

            answer.CreatedAt = DateTime.Now;

            _context.Answers.Add(answer);

            _context.SaveChanges();

            return RedirectToPage("/TopicDetail", new { id = TopicID });
        }
    }
}