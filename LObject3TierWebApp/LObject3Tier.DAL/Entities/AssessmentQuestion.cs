using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class AssessmentQuestion
    {
        public AssessmentQuestion()
        {
            
        }

        [ForeignKey("Assessment")]
        public virtual int AssessmentId { get; set; }

        public virtual Assessment Assessment { get; set; }

        [ForeignKey("Question")]
        public virtual int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public virtual int Order { get; set; }
    }
}
