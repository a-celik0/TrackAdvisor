using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAdvisor.MODELS
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; } = "";
        public string Password { get; set; } = ""; /* "" = so that it will be empty at start */
    }
}