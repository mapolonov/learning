using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual int Id { get; set; }

        [ForeignKey("CourseCategory")]
        public virtual int CourseCategoryId { get; set; }

        [ForeignKey("SaleGroup")]
        public virtual int SaleGroupId { get; set; }

        [MaxLength(50)]
        public virtual string Code { get; set; }


        [MaxLength(200)]
        public virtual string Title { get; set; }

        public virtual bool SelfEnroll { get; set; }

        public virtual bool SelfUnEnroll { get; set; }

        public virtual bool Active { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }

        public virtual SaleGroup SaleGroup { get; set; }

    }
}
