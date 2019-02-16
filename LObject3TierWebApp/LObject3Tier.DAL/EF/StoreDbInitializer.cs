using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.Entities;

namespace LObject3Tier.DAL.EF
{
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            var progr1 = new ProgressState { Name = "Not Started" };
            var progr2 = new ProgressState { Name = "Started" };
            var progr3 = new ProgressState { Name = "Complete" };

            var filial1 = new Filial { Name = "Kiev 01 region" };
            var filial2 = new Filial { Name = "Kiev 02 region" };
            var filial3 = new Filial { Name = "Dnipro 01 region" };
            var filial4 = new Filial { Name = "Kharkiv 01 region" };

            var jobPosition1 = new JobPosition { Name = "Продавец" };
            var jobPosition2 = new JobPosition { Name = "Консультант" };

            var saleGroup1 = new SaleGroup { Code = "SG_INTEL", Name = "Группа продаж Intel" };
            var saleGroup2 = new SaleGroup { Code = "SG_IBM", Name = "Группа продаж IBM" };

            var category1 = new CourseCategory { Name = "Технические курсы", Description = "Технические направления" };
            var category2 = new CourseCategory { Name = "Экономические курсы", Description = "Экономические направления" };

            var course1 = new Course { Code = "TECH0001", CourseCategory = category1, Title = "C#. Advanced.", SaleGroup = saleGroup1 };
            var course2 = new Course { Code = "ECON0001", CourseCategory = category2, Title = "Маркетинг. Продажа RAID-массивов.", SaleGroup = saleGroup2 };

            var lo1 = new LearningObject { Course = course1, Name = "C# Intro", Description = "KPI", Order = 0 };
            var lo2 = new LearningObject { Course = course1, Name = "Math Functions", Description = "KPI", Order = 1 };
            var lo3 = new LearningObject { Course = course1, Name = "String Operations", Description = "KPI", Order = 2 };

            var lo4 = new LearningObject { Course = course2, Name = "Маркетинг IBM", Description = "eco", Order = 0 };
            var lo5 = new LearningObject { Course = course2, Name = "Карта потребительского рынка", Description = "eco", Order = 1 };
            var lo6 = new LearningObject { Course = course2, Name = "Стратегия продаж", Description = "eco", Order = 2 };

            var q1 = new Question {QuestionTypeId = 1, Content = "Who am I?"};
            db.Questions.Add(q1);

            db.Filials.Add(filial1);
            db.Filials.Add(filial2);
            db.Filials.Add(filial3);
            db.Filials.Add(filial4);
            db.JobPositions.Add(jobPosition1);
            db.JobPositions.Add(jobPosition2);
            db.SaleGroups.Add(saleGroup1);
            db.SaleGroups.Add(saleGroup2);
            db.CourseCategories.Add(category1);
            db.CourseCategories.Add(category2);
            db.Courses.Add(course1);
            db.Courses.Add(course2);

            db.LearningObjects.Add(lo1);
            db.LearningObjects.Add(lo2);
            db.LearningObjects.Add(lo3);

            db.LearningObjects.Add(lo4);
            db.LearningObjects.Add(lo5);
            db.LearningObjects.Add(lo6);


            //db.SaveChanges();
        }
    }
}
