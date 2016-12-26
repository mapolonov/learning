using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LObject3Tier.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public DbSet<LearningObject> LearningObjects { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseCategory> CourseCategories { get; set; }

        public DbSet<SaleGroup> SaleGroups { get; set; }

        public DbSet<Filial> Filials { get; set; }

        public DbSet<JobPosition> JobPositions { get; set; }

        public ApplicationDbContext()
        {
            
        }

        static ApplicationDbContext()
        {
            //Использовать если хотим запретить CodeFirst 
            //и проверку измененной модели и хеш кода в таблице __MigrationHistory
            //Database.SetInitializer<ApplicationDbContext>(null);

            Database.SetInitializer(new StoreDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasKey(student => student.Id);
            modelBuilder.Entity<Course>()
                .HasKey(course => course.Id);
            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment => new { enrollment.ApplicationUserId, enrollment.CourseId });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(student => student.Enrollments)
                .WithRequired(enrollment => enrollment.ApplicationUser)
                .HasForeignKey(enrollment => enrollment.ApplicationUserId);
            modelBuilder.Entity<Course>()
                .HasMany(course => course.Enrollments)
                .WithRequired(enrollment => enrollment.Course)
                .HasForeignKey(enrollment => enrollment.CourseId);
        }

        
    }
}
