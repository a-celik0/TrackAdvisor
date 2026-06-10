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

        public bool AskQuestion(string content, int topicId, int userId)
        {
            if (string.IsNullOrWhiteSpace(content))
                return false;
            var question = new Question
            {
                Content = content,
                TopicID = topicId,
                UserID = userId //userid is for now hardcoded, but in the future it will be taken from the logged-in user context
            };
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
