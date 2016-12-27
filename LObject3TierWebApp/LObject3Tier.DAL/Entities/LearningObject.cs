using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class LearningObject
    {
        public LearningObject()
        {
            
        }

        public virtual int Id { get; set; }

        public virtual int ParentId { get; set; }

        public virtual int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual int? AssessmentId { get; set; }

        public virtual Assessment Assessment { get; set; }

        public virtual int? LearningObjectTypeId { get; set; }

        public virtual int Order { get; set; }

        [MaxLength(250)]
        public virtual string Name { get; set; }

        [MaxLength(2000)]
        public virtual string Description { get; set; }

        [MaxLength(250)]
        public virtual string Identifier { get; set; }

        [MaxLength(2000)]
        public virtual string Url { get; set; }

        public virtual bool Visible { get; set; }

        public virtual int PassScore { get; set; }

        public virtual int MaxScore { get; set; }

        public virtual bool LaunchInNewWindows { get; set; }

        public virtual int ReviewTimes { get; set; }

        [MaxLength(2000)]
        public virtual string Keywords { get; set; }

       
    }
}
