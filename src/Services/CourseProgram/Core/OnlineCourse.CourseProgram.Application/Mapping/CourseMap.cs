using AutoMapper;
using OnlineCourse.CourseProgram.Application.Dto;
using OnlineCourse.CourseProgram.Application.Dto.Course;

namespace OnlineCourse.CourseProgram.Application.Mapping
{
    public class CourseMap : Profile
    {
        public CourseMap()
        {
            CreateMap<CourseDto, Domain.Models.Course>().ReverseMap();
            CreateMap<CreateCourseDto, Domain.Models.Course>().ReverseMap();
            CreateMap<UpdateCourseDto, Domain.Models.Course>().ReverseMap();
        }
    }
}
