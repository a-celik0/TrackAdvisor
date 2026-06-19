using System.Collections.Generic;
using System.Linq;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.Tests
{
    // Fake repository — no database connection
    // Only stores topics in a list in memory
    public class FakeTopicRepository : ITopicRepository
    {
        // In-memory list instead of database
        private List<Topic> _topics = new List<Topic>();
        private int _nextId = 1;

        // Return only topics that are not deleted
        public List<Topic> FindAll()
        {
            return _topics.Where(t => !t.IsDeleted).ToList();
        }

        // Return all topics including deleted ones
        public List<Topic> FindAllIncludingDeleted()
        {
            return _topics;
        }

        // Find topic by ID
        public Topic FindByID(int id)
        {
            return _topics.FirstOrDefault(t => t.TopicID == id);
        }

        // Add a new topic to the list
        public void Add(string name, string description)
        {
            var topic = new Topic
            {
                TopicID = _nextId++,
                Name = name,
                Description = description,
                IsDeleted = false
            };
            _topics.Add(topic);
        }

        // Update topic name and description
        public void Update(int id, string name, string description)
        {
            var topic = _topics.FirstOrDefault(t => t.TopicID == id);
            if (topic != null)
            {
                topic.Name = name;
                topic.Description = description;
            }
        }

        // Soft delete a topic — set IsDeleted to true
        public void SoftDelete(int id)
        {
            var topic = _topics.FirstOrDefault(t => t.TopicID == id);
            if (topic != null)
            {
                topic.IsDeleted = true;
            }
        }

        // Restore a soft deleted topic
        public void Restore(int id)
        {
            var topic = _topics.FirstOrDefault(t => t.TopicID == id);
            if (topic != null)
            {
                topic.IsDeleted = false;
            }
        }
    }
}