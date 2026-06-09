using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.MODELS.Interfaces
{
    public interface IAnswerRepository
    {
        bool Save(Answer answer);  
        List<Answer> FindByQuestionId(int questionId);
    }
}
