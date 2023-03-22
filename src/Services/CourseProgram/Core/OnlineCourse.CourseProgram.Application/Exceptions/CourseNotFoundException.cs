using OnlineCourse.Application.Exceptions;

namespace OnlineCourse.CourseProgram.Application.Exceptions
{
    public class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException() : base(ExceptionMessages.COURSE_NOTFOUND)
        {
        }
    }
}
