using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.BLL.Services
{
    public class AnswerService
    {
        private readonly IAnswerRepository _answerRepository;

       public AnswerService(IAnswerRepository answerRepository)
       {
            _answerRepository = answerRepository;
       }

        public bool SubmitAnswer(string content, int questionId, int userId)
        {
            if (string.IsNullOrWhiteSpace(content))
                return false;
            var answer = new Answer
            {
                Content = content,
                QuestionID = questionId,
                UserID = userId,
            };
            return _answerRepository.Save(answer);
        }

        public List<MODELS.Answer> GetByQuestion(int questionId)
        {
            return _answerRepository.FindByQuestionID(questionId);
        }
    }
}
