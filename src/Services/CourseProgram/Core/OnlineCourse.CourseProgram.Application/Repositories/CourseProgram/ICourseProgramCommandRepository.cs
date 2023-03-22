using OnlineCourse.Application.Repositories;

namespace OnlineCourse.CourseProgram.Application.Repositories.Course
{
    public interface ICourseProgramCommandRepository : ICommandRepository<Domain.Models.CourseProgram>
    {
    }
}
