using LObject3Tier.DAL.EF;
using LObject3Tier.DAL.Entities;

namespace LObject3Tier.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //!!!!!!!!!!! need it!!! -))
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //var physicsCourse = new Course() { Title = "Physics" };
            //var mathCourse = new Course() { Title = "Math" };

            //var physicsCourseEnrollmentJohn = new Enrollment() { ApplicationUserId = "23d2958e-5bd2-4df1-9c18-9e0995870069", Course = physicsCourse };
            //var mathCourseEnrollmentJohn = new Enrollment() { ApplicationUserId = "23d2958e-5bd2-4df1-9c18-9e0995870069", Course = mathCourse };
            //var physicsCourseEnrollmentJane = new Enrollment() { ApplicationUserId = "23d2958e-5bd2-4df1-9c18-9e0995870069", Course = physicsCourse };

            //context.Courses.Add(physicsCourse);
            //context.Courses.Add(mathCourse);

            //physicsCourse.Enrollments.Add(physicsCourseEnrollmentJohn);
            //mathCourse.Enrollments.Add(mathCourseEnrollmentJohn);
            //physicsCourse.Enrollments.Add(physicsCourseEnrollmentJane);

            //context.Enrollments.Add(physicsCourseEnrollmentJohn);
            //context.Enrollments.Add(mathCourseEnrollmentJohn);
            //context.Enrollments.Add(physicsCourseEnrollmentJane);

            //context.SaveChanges();
        }
    }
}
