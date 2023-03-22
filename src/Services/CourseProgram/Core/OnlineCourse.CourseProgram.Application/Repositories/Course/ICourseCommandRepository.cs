using OnlineCourse.Application.Repositories;

namespace OnlineCourse.CourseProgram.Application.Repositories.Course
{
    public interface ICourseCommandRepository : ICommandRepository<Domain.Models.Course>
    {
    }
}
