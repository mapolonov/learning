using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        public IEnumerable<LearningObjectDTO> GetCourses()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.Initialize(cfg => cfg.CreateMap<LearningObject, LearningObjectDTO>());
            return Mapper.Map<IEnumerable<LearningObject>, List<LearningObjectDTO>>(_unitOfWork.LearningObjects.GetAll());
        }

        public void DeleteCourse(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id курса", "");

            _unitOfWork.LearningObjects.Delete(id.Value);
            _unitOfWork.Save();
        }

        public LearningObjectDTO GetCourse(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id курса", "");
            var obj = _unitOfWork.LearningObjects.Get(id.Value);
            if (obj == null)
                throw new ValidationException("Курс не найден", "");
            // применяем автомаппер для проекции Phone на PhoneDTO
            Mapper.Initialize(cfg => cfg.CreateMap<LearningObject, LearningObjectDTO>());
            return Mapper.Map<LearningObject, LearningObjectDTO>(obj);
        }

        public void CreateNewCourse(LearningObjectDTO lo)
        {
            if (string.IsNullOrEmpty(lo.Name))
                throw new ValidationException("Course Name cannot be empty", "");

            if (string.IsNullOrEmpty(lo.Company))
                throw new ValidationException("Course Company cannot be empty", "");

            _unitOfWork.LearningObjects.Create(new LearningObject {Name = lo.Name, Description = lo.Company});
            _unitOfWork.Save();
        }

        public void UpdateCourse(LearningObjectDTO lo)
        {
            if (lo.Id <= 0)
                throw new ValidationException("Course Id cannot be empty", "");

            if (string.IsNullOrEmpty(lo.Name))
                throw new ValidationException("Course Name cannot be empty", "");

            if (string.IsNullOrEmpty(lo.Company))
                throw new ValidationException("Course Company cannot be empty", "");
            var objToUpdate = _unitOfWork.LearningObjects.Get(lo.Id);
            objToUpdate.Name = lo.Name;
            objToUpdate.Description = lo.Company;
            _unitOfWork.LearningObjects.Update(objToUpdate);
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
