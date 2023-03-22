using OnlineCourse.Application.Repositories;
using OnlineCourse.CourseProgram.Application.Dto.Course;

namespace OnlineCourse.CourseProgram.Application.Repositories.Course
{
    public interface ICourseProgramRepository : IRepository<Domain.Models.CourseProgram, CourseProgramSearchDto>
    {
    }
}
