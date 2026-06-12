using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class AskQuestionModel : PageModel
    {
        // Using QuestionService instead of AppDbContext
        private readonly QuestionService _questionService;

        // Question content coming from the form
        [BindProperty]
        public string Content { get; set; } = string.Empty;

        // TopicId from form (which topic does this question belong to?)
        [BindProperty]
        public int TopicID { get; set; }

        // Constructor — QuestionService comes from outside (Dependency Injection)
        public AskQuestionModel(QuestionService questionService)
        {
            _questionService = questionService;
        }

        // Runs when the page is loaded
        // Gets the topicId from the URL and saves it to TopicID property
        public IActionResult OnGet(int topicId)
        {
            // Check if user is logged in
            if (Request.Cookies["UserID"] == null)
            {
                return RedirectToPage("/Login");
            }

            // Save the topicId from the URL
            TopicID = topicId;
            return Page();
        }

        // Runs when the form is submitted
        public IActionResult OnPost()
        {
            // Create a new question object
            var question = new Question();

            // Save the content from the form
            question.Content = Content;

            // Save the topicId to the question
            question.TopicID = TopicID;

            // Get UserID from cookie
            question.UserID = int.Parse(Request.Cookies["UserID"]);

            // Save the current time
            question.CreatedAt = DateTime.Now;

            // Save question using QuestionService
            _questionService.AskQuestion(question);

            // Go back to the topic detail page
            return RedirectToPage("/TopicDetail", new { id = TopicID });
        }
    }
}