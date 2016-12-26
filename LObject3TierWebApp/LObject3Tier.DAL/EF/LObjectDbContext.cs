using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.Entities;

namespace LObject3Tier.DAL.EF
{
    //public class LObjectDbContext : DbContext
    //{
    //    public DbSet<LearningObject> LearningObjects { get; set; }

    //    public DbSet<Enrollment> Enrollments { get; set; }

    //    public DbSet<Course> Courses { get; set; }



    //    static LObjectDbContext()
    //    {
    //        Database.SetInitializer(new StoreDbInitializer());
    //    }

    //    public LObjectDbContext(string connectionString) : base(connectionString)
    //    {
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<ApplicationUser>()
    //            .HasKey(student => student.Id);
    //        modelBuilder.Entity<Course>()
    //            .HasKey(course => course.CourseId);
    //        modelBuilder.Entity<Enrollment>()
    //            .HasKey(enrollment => new { enrollment.ApplicationUserId, enrollment.CourseId });

    //        modelBuilder.Entity<ApplicationUser>()
    //            .HasMany(student => student.Enrollments)
    //            .WithRequired(enrollment => enrollment.ApplicationUser)
    //            .HasForeignKey(enrollment => enrollment.ApplicationUserId);
    //        modelBuilder.Entity<Course>()
    //            .HasMany(course => course.Enrollments)
    //            .WithRequired(enrollment => enrollment.Course)
    //            .HasForeignKey(enrollment => enrollment.CourseId);
    //    }

    //}

    //public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<LObjectDbContext>
    //{
    //    protected override void Seed(LObjectDbContext db)
    //    {
    //        //db.LearningObjects.Add(new LearningObject {Name = "Math Part 1", Company = "KPI"});
    //        //db.LearningObjects.Add(new LearningObject { Name = "Math Part 2", Company = "KPI" });
    //        //db.LearningObjects.Add(new LearningObject { Name = "Economics Basic", Company = "Lviv Politeh" });
    //        //db.LearningObjects.Add(new LearningObject { Name = "Computers Advance", Company = "Kharkiv Politeh" });

    //        //db.Students.Add(new Student {Name = "Mikki"});
    //        //db.Students.Add(new Student { Name = "Andy" });
    //        //db.Students.Add(new Student { Name = "Elena" });
    //        //db.Students.Add(new Student { Name = "Liliya" });


    //        //db.SaveChanges();
    //    }
    //}
}
