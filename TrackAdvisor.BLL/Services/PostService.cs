using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.BLL.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public bool CreatePost(ExperiencePost post)
        {
            if (post == null || string.IsNullOrWhiteSpace(post.Content) || post.TopicID <= 0)
            {
                return false;
            }
            _postRepository.Save(post);
            return true;
        }

        public List<ExperiencePost> GetPostsByTopic(int topicId)
        {
            if (topicId <= 0)
            {
                return new List<ExperiencePost>();
            }
            return _postRepository.FindByTopicID(topicId);
        }
        public void DeletePost(int postId)
        {
            if (postId <= 0)
            {
                return;
            }
            _postRepository.Delete(postId);
        }
    }
}
