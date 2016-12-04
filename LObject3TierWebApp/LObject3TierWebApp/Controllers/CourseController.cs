using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using LObject3Tier.BLL.DTO;
using LObject3Tier.BLL.Infrastructure;
using LObject3Tier.BLL.Interfaces;
using LObject3TierWebApp.ViewModels;

namespace LObject3TierWebApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService service)
        {
            _courseService = service;
        }

        protected override void Dispose(bool disposing)
        {
            _courseService.Dispose();
            base.Dispose(disposing);
        }

        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<LearningObjectDTO> objDtos = _courseService.GetCourses();
            Mapper.Initialize(cfg => cfg.CreateMap<LearningObjectDTO, CourseViewModel>());
            var courses = Mapper.Map<IEnumerable<LearningObjectDTO>, List<CourseViewModel>>(objDtos);
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                LearningObjectDTO lo = _courseService.GetCourse(id);
                Mapper.Initialize(cfg => cfg.CreateMap<LearningObjectDTO, CourseViewModel>()
                    .ForMember("Id", opt => opt.MapFrom(src => src.Id)));
                var course = Mapper.Map<LearningObjectDTO, CourseViewModel>(lo);
                return View(course);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseViewModel courceViewModel)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<CourseViewModel, LearningObjectDTO>());
                var courseDto = Mapper.Map<CourseViewModel, LearningObjectDTO>(courceViewModel);
                _courseService.CreateNewCourse(courseDto);
                ViewBag.Message = "<h2>Ваш курс успешно зарегистрирован</h2>";
                //return Content("<h2>Ваш курс успешно зарегистрирован</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            //return View(courceViewModel);
            return RedirectToAction("Index");
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                LearningObjectDTO lo = _courseService.GetCourse(id);
                Mapper.Initialize(cfg => cfg.CreateMap<LearningObjectDTO, CourseViewModel>()
                    .ForMember("Id", opt => opt.MapFrom(src => src.Id)));
                var course = Mapper.Map<LearningObjectDTO, CourseViewModel>(lo);
                return View(course);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel courceViewModel)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<CourseViewModel, LearningObjectDTO>());
                var courseDto = Mapper.Map<CourseViewModel, LearningObjectDTO>(courceViewModel);
                _courseService.UpdateCourse(courseDto);
                ViewBag.Message = "<h2>Ваш курс успешно обновлен</h2>";
                //return Content("<h2>Ваш курс успешно зарегистрирован</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            //return View(courceViewModel);
            return RedirectToAction("Index");
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                LearningObjectDTO lo = _courseService.GetCourse(id);
                Mapper.Initialize(cfg => cfg.CreateMap<LearningObjectDTO, CourseViewModel>()
                    .ForMember("Id", opt => opt.MapFrom(src => src.Id)));
                var course = Mapper.Map<LearningObjectDTO, CourseViewModel>(lo);
                return View(course);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CourseViewModel courceViewModel)
        {
            try
            {
                _courseService.DeleteCourse(id);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
