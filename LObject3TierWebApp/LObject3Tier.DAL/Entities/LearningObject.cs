using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class LearningObject
    {
        public LearningObject()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}
