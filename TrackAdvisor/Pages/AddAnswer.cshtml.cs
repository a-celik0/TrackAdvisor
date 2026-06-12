using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.BLL.Services;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class AddAnswerModel : PageModel
    {
        private readonly AnswerService _answerService;

        // The question content coming from the form
        [BindProperty]
        public string Content { get; set; } = string.Empty;

        [BindProperty]
        public int QuestionID { get; set; }

        [BindProperty]
        public int TopicID { get; set; }

        public AddAnswerModel(AnswerService answerService)
        {
            _answerService = answerService;
        }

        public IActionResult OnGet(int questionId, int topicId)
        {
            if (Request.Cookies["UserID"] == null)
            {
                return RedirectToPage("/Login");
            }

            TopicID = topicId;
            QuestionID = questionId;

            return Page();
        }

        public IActionResult OnPost()
        {
            // Crate a new answer object
            var answer = new Answer();

            answer.Content = Content;

            // Check which question this answer belongs to
            answer.QuestionID = QuestionID;

            //int.Parse: change string to integer
            answer.UserID = int.Parse(Request.Cookies["UserID"]);

            answer.CreatedAt = DateTime.Now;

           _answerService.SubmitAnswer(answer);

            return RedirectToPage("/TopicDetail", new { id = TopicID });
        }
    }
}