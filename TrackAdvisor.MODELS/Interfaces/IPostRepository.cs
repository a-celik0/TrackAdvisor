using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAdvisor.MODELS.Interfaces
{
    public interface IPostRepository
    {
        bool Save(ExperiencePost post);
        List<ExperiencePost> FindByTopicId(int topicId);
         void Delete(int id);
    }
}
