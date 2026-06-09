using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS.Interfaces;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.Tests
{
    public class FakeAnswerRepository : IAnswerRepository
    {
        private List<Answer> _answers = new List<Answer>();

        public bool Save(Answer answer)
        {
            _answers.Add(answer);
            return true;
        }

        public List<Answer> FindByQuestionId(int questionId)
        {
            return _answers.Where(a => a.QuestionID == questionId).ToList();
        }
    }
}
