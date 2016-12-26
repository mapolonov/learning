using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class CourseCategory
    {
        public CourseCategory()
        {
            
        }

        public virtual int Id { get; set; }

        [MaxLength(100)]
        public virtual string Name { get; set; }

        [MaxLength(250)]
        public virtual string Description { get; set; }

    }
}
