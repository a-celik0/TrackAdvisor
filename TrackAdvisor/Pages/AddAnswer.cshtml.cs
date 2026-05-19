using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class AddAnswerModel : PageModel
    {
        // Veritabanýna baðlanmak için köprü
        private readonly AppDbContext _context;

        // Formdan gelecek soru metni
        [BindProperty]
        public string Content { get; set; } = string.Empty;

        // Formdan gelecek question ID'si (hangi topic'e ait bu soru?)
        [BindProperty]
        public int QuestionID { get; set; }

        [BindProperty]
        public int TopicID { get; set; }

        // Constructor — sistem AppDbContext'i veriyor, biz kaydediyoruz
        public AddAnswerModel(AppDbContext context)
        {
            _context = context;
        }

        // Sayfa açýlýnca çalýþýr
        // topicId ? URL'den geliyor (/AskQuestion?topicId=1)
        public void OnGet(int questionId, int topicId)
        {
            // URL'den gelen topicId'yi TopicID'ye kaydediyoruz
            // Çünkü form gönderilince hangi topic'e ait olduðunu bilmemiz lazým
            TopicID = topicId;
            QuestionID = questionId;
        }

        // Form gönderilince çalýþýr
        public IActionResult OnPost()
        {
            // Yeni bir soru nesnesi oluþtur
            var answer = new Answer();

            // Formdan gelen metni kaydet
            answer.Content = Content;

            // Hangi topic'e ait olduðunu kaydet
            answer.QuestionID = QuestionID;

            // Þimdilik sabit, sonra cookie'den alacaðýz
            answer.UserID = 1;

            // Þu anki zamaný kaydet
            answer.CreatedAt = DateTime.Now;

            // Soruyu veritabanýna ekle
            _context.Answers.Add(answer);

            // Veritabanýna kaydet
            _context.SaveChanges();

            // TopicDetail sayfasýna geri dön
            return RedirectToPage("/TopicDetail", new { id = TopicID });
        }
    }
}