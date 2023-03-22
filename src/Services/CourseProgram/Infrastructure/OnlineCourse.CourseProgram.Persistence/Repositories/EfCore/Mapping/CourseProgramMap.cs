using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCourse.Persistence.Repository.EfCore.Mapping;

namespace OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Mapping
{
    public class CourseProgramMap : BaseEntityMap<Domain.Models.CourseProgram>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.CourseProgram> builder)
        {
            base.Configure(builder);

            builder.ToTable("CoursePrograms");

            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.IsActive).HasDefaultValue(true);    

        }
    }
}
