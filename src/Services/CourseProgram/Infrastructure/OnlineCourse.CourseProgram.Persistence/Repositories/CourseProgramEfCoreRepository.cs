using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Repositories.Course;
using OnlineCourse.CourseProgram.Persistence.Repositories.EfCore.Context;
using OnlineCourse.Persistence.Repository.EfCore;
using OnlineCourse.Persistence.Repository.Extensions;
using System.Linq;

namespace OnlineCourse.CourseProgram.Persistence.Repositories
{
    public class CourseProgramEfCoreRepository : BaseEfCoreRepository<CourseProgramDbContext, Domain.Models.CourseProgram, CourseProgramSearchDto>, ICourseProgramRepository,
        ICourseProgramReadOnlyRepository, ICourseProgramCommandRepository
    {
        public CourseProgramEfCoreRepository(CourseProgramDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Domain.Models.CourseProgram> CreateFilteredQuery(CourseProgramSearchDto searchEntity)
        {
            IQueryable<Domain.Models.CourseProgram> courseProgram = TableNoTracking.AsQueryable();

            courseProgram = courseProgram.WhereIf(searchEntity.Id.HasValue, p => p.Id == searchEntity.Id.Value)
                .WhereIf(searchEntity.IsActive.HasValue, p => p.IsActive == searchEntity.IsActive.Value)
                .WhereIf(!searchEntity.IsActive.HasValue, p => p.IsActive == true)
                .WhereIf(!string.IsNullOrEmpty(searchEntity.Name), p => p.Name.ToLower().StartsWith(searchEntity.Name.ToLower()))
                .WhereIf(searchEntity.StartTime.HasValue, p => p.StartTime >= searchEntity.StartTime.Value)
                .WhereIf(searchEntity.EndTime.HasValue, p => p.EndTime <= searchEntity.EndTime.Value);

            return courseProgram;
        }

    }
}
