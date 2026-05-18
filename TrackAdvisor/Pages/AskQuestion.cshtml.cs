using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.WEB.Pages
{
    public class AskQuestionModel : PageModel
    {
        // Veritabanýna baðlanmak için köprü
        private readonly AppDbContext _context;

        // Formdan gelecek soru metni
        [BindProperty]
        public string Content { get; set; } = string.Empty;

        // Formdan gelecek topic ID'si (hangi topic'e ait bu soru?)
        [BindProperty]
        public int TopicID { get; set; }

        // Constructor — sistem AppDbContext'i veriyor, biz kaydediyoruz
        public AskQuestionModel(AppDbContext context)
        {
            _context = context;
        }

        // Sayfa açýlýnca çalýþýr
        // topicId ? URL'den geliyor (/AskQuestion?topicId=1)
        public void OnGet(int topicId)
        {
            // URL'den gelen topicId'yi TopicID'ye kaydediyoruz
            // Çünkü form gönderilince hangi topic'e ait olduðunu bilmemiz lazým
            TopicID = topicId;
        }

        // Form gönderilince çalýþýr
        public IActionResult OnPost()
        {
            // Yeni bir soru nesnesi oluþtur
            var question = new Question();

            // Formdan gelen metni kaydet
            question.Content = Content;

            // Hangi topic'e ait olduðunu kaydet
            question.TopicID = TopicID;

            // Þimdilik sabit, sonra cookie'den alacaðýz
            question.UserID = 1;

            // Þu anki zamaný kaydet
            question.CreatedAt = DateTime.Now;

            // Soruyu veritabanýna ekle
            _context.Questions.Add(question);

            // Veritabanýna kaydet
            _context.SaveChanges();

            // TopicDetail sayfasýna geri dön
            return RedirectToPage("/TopicDetail", new { id = TopicID });
        }
    }
}