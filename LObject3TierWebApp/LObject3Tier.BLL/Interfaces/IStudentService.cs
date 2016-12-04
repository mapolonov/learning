using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.BLL.DTO;

namespace LObject3Tier.BLL.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetStudents();

        StudentDTO GetStudent(int? id);
    }
}
