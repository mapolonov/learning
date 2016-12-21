using System;
using System.Collections.Generic;
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

        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual string OrderCode { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime ModifiedDate { get; set; }


    }
}
