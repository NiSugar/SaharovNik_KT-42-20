using Microsoft.EntityFrameworkCore;
using SaharovNik_KT_42_20.Database.Configurations;
using SaharovNik_KT_42_20.Models;
using System.Text.RegularExpressions;
using Group = SaharovNik_KT_42_20.Models.Group;

namespace SaharovNik_KT_42_20.Database
{
    public class StudentDbContext : DbContext
    {
        public  DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
    }
}
