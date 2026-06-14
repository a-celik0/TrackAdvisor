using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS.Interfaces;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.BLL.Services
{
    public class TopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public List<Topic> GetAllTopics()
        {
            return _topicRepository.FindAll();
        }

        public Topic GetTopicByID(int id)
        {
            return _topicRepository.FindByID(id);
        }

        public void UpdateTopic(int id, string name, string description)
        {
            _topicRepository.Update(id, name, description);
        }

        public void SoftDeleteTopic(int id)
        {
            _topicRepository.SoftDelete(id);
        }
    }
}
