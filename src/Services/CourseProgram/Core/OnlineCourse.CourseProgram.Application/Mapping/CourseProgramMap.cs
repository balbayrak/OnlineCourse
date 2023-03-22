using AutoMapper;
using OnlineCourse.CourseProgram.Application.Dto;
using OnlineCourse.CourseProgram.Application.Dto.Course;

namespace OnlineCourse.CourseProgram.Application.Mapping
{
    public class CourseProgramMap : Profile
    {
        public CourseProgramMap()
        {
            CreateMap<CourseProgramDto, Domain.Models.CourseProgram>().ReverseMap();
            CreateMap<CreateCourseProgramDto, Domain.Models.CourseProgram>().ReverseMap();
            CreateMap<UpdateCourseProgramDto, Domain.Models.CourseProgram>().ReverseMap();
        }
    }
}
