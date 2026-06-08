using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAdvisor.MODELS
{
    public class Question
    {
        public int QuestionID { get; set; }

        public int UserID { get; set; }

        public int TopicID { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
    }
}