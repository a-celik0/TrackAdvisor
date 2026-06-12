using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS.Interfaces;
using TrackAdvisor.MODELS;

namespace TrackAdvisor.Tests
{
    public class FakePostRepository : IPostRepository
    {
        private List<ExperiencePost> _experiencePosts = new List<ExperiencePost>();

        public bool Save(ExperiencePost post)
        {
            _experiencePosts.Add(post);
            _experiencePosts.Add(post);
            return true;
        }

        public List<ExperiencePost> FindByTopicID(int topicId)
        {
            return _experiencePosts.
                Where(p => p.TopicID == topicId)
                .ToList();
        }

        public void Delete(int id)
        {
            var post = _experiencePosts.FirstOrDefault(p => p.ExperiencePostID == id);
            if (post != null)
            {
                _experiencePosts.Remove(post);
            }
        }
    }
}
