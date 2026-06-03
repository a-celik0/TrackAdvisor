using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.Tests
{
    public class FakeQuestionRepository : IQuestionRepository
    {
        //notebook(new one)
        private List<Question> _questions = new List<Question>();

        //writing to notebook = save
        public bool Save(Question question)
        {
            _questions.Add(question);
            return true;
        }

        //Search in the notebook 
        public List<Question> FindByTopicID(int topicId)
        {
            return _questions.Where(q => q.TopicID == topicId).ToList();
        }

        //erase from the notebook
        public void Delete(int id)
        {
            var question = _questions.FirstOrDefault(q => q.QuestionID == id);
            if (question != null)
            {
                _questions.Remove(question);
            }
        }
    }
}
