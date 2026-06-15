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

        public bool SubmitAnswer(Answer answer)
        {
            // If answer object is null, throw an exception
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            // If content is empty or whitespace, return false
            if (string.IsNullOrWhiteSpace(answer.Content))
                return false;

            return _answerRepository.Save(answer);
        }

        public List<MODELS.Answer> GetByQuestion(int questionId)
        {
            return _answerRepository.FindByQuestionID(questionId);
        }
    }
}
