using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAdvisor.MODELS.Interfaces
{
    public interface ITopicRepository
    {
        List<Topic> FindAll();
        List<Topic> FindAllIncludingDeleted();
        Topic FindByID(int id);
        void Update(int id, string name, string description);
        void SoftDelete(int id);
        void Add(string name, string description);
        void Restore(int id);
    }
}
