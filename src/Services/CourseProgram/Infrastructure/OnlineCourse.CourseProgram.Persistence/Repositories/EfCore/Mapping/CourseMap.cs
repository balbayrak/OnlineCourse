using OnlineCourse.CourseProgram.Domain.Models;
using OnlineCourse.Persistence.Repository.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Mapping
{
    public class CourseMap : BaseEntityMap<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.ToTable("Courses");

            builder.Property(p => p.ProgramId).IsRequired();

            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.Program)
                .WithMany(p => p.Courses)
                .HasForeignKey(p => p.ProgramId);

        }
    }
}
