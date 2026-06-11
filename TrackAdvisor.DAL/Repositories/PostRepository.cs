using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAdvisor.DAL.Data;
using TrackAdvisor.MODELS;
using TrackAdvisor.MODELS.Interfaces;

namespace TrackAdvisor.DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Save(ExperiencePost post)
        {
            _context.ExperiencePosts.Add(post);
            _context.SaveChanges();
            return true;
        }
        public List<ExperiencePost> FindByTopicID(int topicId)
        {
            return _context.ExperiencePosts
                .Where(p => p.TopicID == topicId)
                .ToList();
        }
        public void Delete(int id)
        {
            var post = _context.ExperiencePosts.FirstOrDefault(p => p.ExperiencePostID == id);
            if (post != null)
            {
                _context.ExperiencePosts.Remove(post);
                _context.SaveChanges();
            }
        }
    }
    }
