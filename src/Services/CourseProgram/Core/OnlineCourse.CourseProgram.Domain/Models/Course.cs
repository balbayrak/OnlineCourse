using OnlineCourse.Domain;

namespace OnlineCourse.CourseProgram.Domain.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    
        public string Url { get; set; }

        public Guid ProgramId { get; set; }

        public virtual CourseProgram Program { get; set; }
    }
}
