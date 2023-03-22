using OnlineCourse.Application.Repositories;
using OnlineCourse.CourseProgram.Application.Dto.Course;

namespace OnlineCourse.CourseProgram.Application.Repositories.Course
{
    public interface ICourseReadOnlyRepository : IReadOnlyRepository<Domain.Models.Course, CourseSearchDto>
    {
    }
}
