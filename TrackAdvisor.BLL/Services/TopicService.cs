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
        public List<Topic> GetAllTopicsIncludingDeleted()
        {
            return _topicRepository.FindAllIncludingDeleted();
        }
        public Topic GetTopicByID(int id)
        {
            return _topicRepository.FindByID(id);
        }

        public void SoftDeleteTopic(int id)
        {
            _topicRepository.SoftDelete(id);
        }
        public bool AddTopic(string name, string description)
        {
            // If name or description is empty, do not add
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                return false;

            _topicRepository.Add(name, description);
            return true;
        }

        public bool UpdateTopic(int id, string name, string description)
        {
            // If name or description is empty, do not update
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
                return false;

            _topicRepository.Update(id, name, description);
            return true;
        }
        public void RestoreTopic(int id)
        {
            _topicRepository.Restore(id);
        }
    }
}
