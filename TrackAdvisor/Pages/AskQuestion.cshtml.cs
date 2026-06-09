using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class AskQuestionModel : PageModel
    {
        // A bridge to the database
        private readonly AppDbContext _context;

        // Question content coming from the form
        [BindProperty]
        public string Content { get; set; } = string.Empty;

        // TopicId from form (which topic does this question belong to?)
        [BindProperty]
        public int TopicID { get; set; }

        // Constructor - system gives us AppDbContext, we save it
        public AskQuestionModel(AppDbContext context)
        {
            _context = context;
        }

        // It works when the page is loaded, it gets the topicId from the URL and saves it to TopicID property
        public void OnGet(int topicId)
        {
            // we save the topicId from the URL to TopicID property
            // because when the form is submitted, we need to know which topic it belongs to

            TopicID = topicId;
        }

        // It works when the form is submitted, it creates a new question and saves it to the database
        public IActionResult OnPost()
        {
            // Crate a new question object
            var question = new Question();

            // Save the content from the form
            question.Content = Content;

            // Save the topicId to the question
            question.TopicID = TopicID;

            // Now same for all, will be changed after the cookie
            question.UserID = int.Parse(Request.Cookies["UserID"]);

            // Save the current time to the question
            question.CreatedAt = DateTime.Now;

            // Add the question to the database
            _context.Questions.Add(question);

            // save the changes to the database
            _context.SaveChanges();

            // Back to the topic detail page, we need to give the topicId to show the right topic
            return RedirectToPage("/TopicDetail", new { id = TopicID });
        }
    }
}