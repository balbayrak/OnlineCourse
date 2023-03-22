using Microsoft.EntityFrameworkCore;
using OnlineCourse.CourseProgram.Domain.Models;
using OnlineCourse.Persistence.Repository.EfCore.Context;

namespace OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Context
{
    public class CourseProgramDbContext : CoreDbContext
    {
        public CourseProgramDbContext()
        {
        }
        public CourseProgramDbContext(DbContextOptions<CourseProgramDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Domain.Models.CourseProgram> CoursePrograms { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
