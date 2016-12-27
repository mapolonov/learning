using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class Question
    {
        public Question()
        {
            
        }

        public virtual int Id { get; set; }

        public virtual int QuestionTypeId { get; set; }

        [MaxLength(2000)]
        public virtual string Content { get; set; }

        public virtual ICollection<AssessmentQuestion> AssessmentQuestions { get; set; }

    }
}
