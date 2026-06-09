using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS.Interfaces;
using TrackAdvisor.MODELS;
using TrackAdvisor.DAL.Data;

namespace TrackAdvisor.DAL.Repositories
{
    // Real repository — connected to the database using EF Core
    // Implements IAnswerRepository contract
    public class AnswerRepository : IAnswerRepository
    {
        // Bridge to connect to the database
        private readonly AppDbContext _context;

        // Constructor — AppDbContext comes from outside (Dependency Injection)
        public AnswerRepository(AppDbContext context)
        {
            _context = context;
        }

        // Save a new answer to the database
        // Returns true if successful
        public bool Save(Answer answer)
        {
            // Add the answer to the database
            _context.Answers.Add(answer);

            // Save changes to the database
            _context.SaveChanges();

            return true;
        }

        // Get all answers belonging to a specific question
        public List<Answer> FindByQuestionId(int questionId)
        {
            // Return all answers where QuestionID matches
            return _context.Answers
                .Where(a => a.QuestionID == questionId)
                .ToList();
        }
    }
}
