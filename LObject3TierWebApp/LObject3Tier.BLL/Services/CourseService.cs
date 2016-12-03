using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.BLL.DTO;
using LObject3Tier.BLL.Infrastructure;
using LObject3Tier.BLL.Interfaces;
using LObject3Tier.DAL.Entities;
using LObject3Tier.DAL.Interfaces;

namespace LObject3Tier.BLL.Services
{
    public class CourseService : ICourseService
    {
        private IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public void CreateNewCourse(LearningObjectDTO lo)
        {
            if (string.IsNullOrEmpty(lo.Name))
                throw new ValidationException("Course Name cannot be empty", "");

            if (string.IsNullOrEmpty(lo.Company))
                throw new ValidationException("Course Company cannot be empty", "");

            _unitOfWork.LearningObjects.Create(new LearningObject {Name = lo.Name, Company = lo.Company});
            _unitOfWork.Save();
        }

        public void RegisterStudentOnCourse(LearningObjectDTO lo, StudentDTO student)
        {
            throw new NotImplementedException();
        }

        public void TakeCourseOffline(LearningObjectDTO lo)
        {
            throw new NotImplementedException();
        }

        public void TakeCourseOnline(LearningObjectDTO lo)
        {
            throw new NotImplementedException();
        }

        public void UnRegisterStudentOnCourse(LearningObjectDTO lo, StudentDTO student)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
