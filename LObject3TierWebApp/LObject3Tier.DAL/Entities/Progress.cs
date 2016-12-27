using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class Progress
    {
        public Progress()
        {
            
        }

        public virtual int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public virtual string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("LearningObject")]
        public virtual int LearningObjectId { get; set; }

        public virtual LearningObject LearningObject { get; set; }

        public virtual DateTime StartTime { get; set; }

        public virtual DateTime EndTime { get; set; }

        public virtual int Score { get; set; }

        [ForeignKey("ProgressState")]
        public virtual int ProgressStateId { get; set; }

        public virtual ProgressState ProgressState { get; set; }

        public virtual int Attempts { get; set; }
    }
}
