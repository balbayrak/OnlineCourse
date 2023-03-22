using OnlineCourse.Application.Exceptions;

namespace OnlineCourse.CourseProgram.Application.Exceptions
{
    public class CourseProgramNotFoundException : NotFoundException
    {
        public CourseProgramNotFoundException() : base(ExceptionMessages.COURSE_NOTFOUND)
        {
        }
    }
}
