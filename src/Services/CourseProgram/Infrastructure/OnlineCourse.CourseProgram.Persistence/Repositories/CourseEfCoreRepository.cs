using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Repositories.Course;
using OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Context;
using OnlineCourse.Persistence.Repository.EfCore;
using OnlineCourse.Persistence.Repository.Extensions;
using System.Linq;

namespace OnlineCourse.CourseProgram.Persistence.Repositories
{
    public class CourseEfCoreRepository : BaseEfCoreRepository<CourseProgramDbContext, Domain.Models.Course, CourseSearchDto>, ICourseRepository, ICourseReadOnlyRepository, ICourseCommandRepository
    {
        public CourseEfCoreRepository(CourseProgramDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Domain.Models.Course> CreateFilteredQuery(CourseSearchDto searchEntity)
        {
            IQueryable<Domain.Models.Course> courseProgram = TableNoTracking.AsQueryable();

            courseProgram = courseProgram.WhereIf(searchEntity.Id.HasValue, p => p.Id == searchEntity.Id.Value)
                .WhereIf(searchEntity.ProgramId.HasValue, p => p.ProgramId == searchEntity.ProgramId.Value)
                .WhereIf(!string.IsNullOrEmpty(searchEntity.Name), p => p.Name.ToLower().StartsWith(searchEntity.Name.ToLower()));

            return courseProgram;
        }
    }
}
