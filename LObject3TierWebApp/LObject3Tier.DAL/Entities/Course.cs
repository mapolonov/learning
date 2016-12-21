using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class Course
    {
        public Course()
        {
            
        }

        public virtual int CourseId { get; set; }
        public virtual string CourseName { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
