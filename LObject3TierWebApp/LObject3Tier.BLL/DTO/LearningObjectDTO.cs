using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.Entities;

namespace LObject3Tier.BLL.DTO
{
    public class LearningObjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public virtual ICollection<StudentDTO> Students { get; set; }

    }
}
