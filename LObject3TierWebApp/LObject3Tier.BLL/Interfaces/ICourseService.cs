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
        void CreateNewCourse(LearningObjectDTO lo);

        void RegisterStudentOnCourse(LearningObjectDTO lo, StudentDTO student);

        void UnRegisterStudentOnCourse(LearningObjectDTO lo, StudentDTO student);

        void TakeCourseOffline(LearningObjectDTO lo);

        void TakeCourseOnline(LearningObjectDTO lo);
    }
}
