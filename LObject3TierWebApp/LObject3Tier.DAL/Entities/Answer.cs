using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class Answer
    {
        public Answer()
        {
            
        }

        public virtual int Id { get; set; }

        [ForeignKey("Question")]
        public virtual int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        [MaxLength(2000)]
        public virtual string Content { get; set; }

        public virtual int AnswerValue { get; set; }
        
    }
}
