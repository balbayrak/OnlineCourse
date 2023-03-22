using OnlineCourse.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.CourseProgram.Application.Dto.Course
{
    public class CourseSearchDto : PagedSearchDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid? ProgramId { get; set; }
    }
}
