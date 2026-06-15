using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS.Interfaces;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.BLL.Services
{
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public bool AskQuestion(Question question)
        {
            // If question object is null, throw an exception
            // This prevents a NullReferenceException later
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            // If content is empty or whitespace, return false
            if (string.IsNullOrWhiteSpace(question.Content))
                return false;

            // Save the question to the database
            return _questionRepository.Save(question);
        }

        public List<MODELS.Question> GetQuestionsByTopic(int topicId)
        {
            return _questionRepository.FindByTopicID(topicId);
        }

        public void DeleteQuestion(int questionId)
        {
            _questionRepository.Delete(questionId);
        }
    }
}
