using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject3Tier.BLL.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<LearningObjectDTO> LearningObjects { get; set; }
    }
}
