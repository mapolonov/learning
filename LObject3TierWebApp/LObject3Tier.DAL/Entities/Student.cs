using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class Student
    {
        public Student()
        {
            this.LearningObjects = new HashSet<LearningObject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LearningObject> LearningObjects { get; set; }
    }
}
