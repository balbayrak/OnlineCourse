using OnlineCourse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.CourseProgram.Domain.Models
{
    public class CourseProgram : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();
    }
}
