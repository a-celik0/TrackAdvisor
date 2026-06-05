using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.DAL.Repositories
{
    // Real repository — connected to the database using EF Core
    // Implements IQuestionRepository contract
    public class QuestionRepository : IQuestionRepository
    {
        // Bridge to connect to the database
        private readonly AppDbContext _context;

        // Constructor — AppDbContext comes from outside (Dependency Injection)
        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        // Save a new question to the database
        public bool Save(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return true;
        }

        // Get all questions belonging to a specific topic
        public List<Question> FindByTopicID(int topicId)
        {
            return _context.Questions
                .Where(q => q.TopicID == topicId)
                .ToList();
        }

        // Delete a question by ID
        public void Delete(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.QuestionID == id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }
    }
}