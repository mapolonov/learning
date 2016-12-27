using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class Assessment
    {
        public Assessment()
        {
            
        }

        public virtual int Id { get; set; }

        [MaxLength(20)]
        public virtual string Code { get; set; }

        [MaxLength(250)]
        public virtual string Name { get; set; }

        public virtual bool Mixed { get; set; }

        public virtual int QuestionCount { get; set; }

        public virtual int QuestionDuration { get; set; }

        public virtual bool ForwardOnly { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual ICollection<AssessmentQuestion> AssessmentQuestions { get; set; }
    }
}
