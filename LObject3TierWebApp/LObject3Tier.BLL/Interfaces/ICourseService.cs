using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.BLL.DTO;

namespace LObject3Tier.BLL.Interfaces
{
    public interface ICourseService
    {

        IEnumerable<LearningObjectDTO> GetCourses();

        LearningObjectDTO GetCourse(int? id);

        void DeleteCourse(int? id);

        void CreateNewCourse(LearningObjectDTO lo);

        void UpdateCourse(LearningObjectDTO lo);

        void RegisterStudentOnCourse(LearningObjectDTO lo, StudentDTO student);

        void UnRegisterStudentOnCourse(LearningObjectDTO lo, StudentDTO student);

        void TakeCourseOffline(LearningObjectDTO lo);

        void TakeCourseOnline(LearningObjectDTO lo);

        void Dispose();
    }
}
