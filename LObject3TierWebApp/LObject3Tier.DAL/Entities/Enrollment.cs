using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class Enrollment
    {
        public Enrollment()
        {
            
        }

        [ForeignKey("Course")]
        public virtual int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [MaxLength(20)]
        public virtual string OrderCode { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }


    }
}
