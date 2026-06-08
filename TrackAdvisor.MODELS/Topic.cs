using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAdvisor.MODELS
{
    public class Topic
    {
        public int TopicID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; } //? means it can be null,
                                                 //because when the topic is not deleted, there is no deleted time
    }
}
