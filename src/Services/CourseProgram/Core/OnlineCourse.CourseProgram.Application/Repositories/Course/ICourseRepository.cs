using OnlineCourse.Application.Repositories;
using OnlineCourse.CourseProgram.Application.Dto;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.CourseProgram.Application.Repositories.Course
{
    public interface ICourseRepository : IRepository<Domain.Models.Course, CourseSearchDto>
    {
    }
}
