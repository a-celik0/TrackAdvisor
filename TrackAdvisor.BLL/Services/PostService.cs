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
            // If post object is null, throw an exception
            if (post == null)
                throw new ArgumentNullException(nameof(post));

            // If content is empty or whitespace, return false
            if (string.IsNullOrWhiteSpace(post.Content))
                return false;

            return _postRepository.Save(post);
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
