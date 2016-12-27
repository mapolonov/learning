using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.DAL.Entities
{
    public class ProgressState
    {
        public ProgressState()
        {
            
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

    }
}
