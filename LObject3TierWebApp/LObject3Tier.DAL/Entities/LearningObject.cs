﻿using System;
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
            //this.Students = new HashSet<Student>();
        }

        public virtual int Id { get; set; }

        [MaxLength(100)]
        public virtual string Name { get; set; }

        [MaxLength(100)]
        public virtual string Company { get; set; }

        //public virtual ICollection<Student> Students { get; set; }

    }
}
