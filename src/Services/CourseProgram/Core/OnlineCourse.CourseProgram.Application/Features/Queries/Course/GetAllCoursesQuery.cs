using AutoMapper;
using MediatR;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Queries.Course
{
    public class GetAllCoursesQuery : IRequest<PagedResponse<List<CourseDto>>>
    {
        public CourseSearchDto courseSearchDto { get; set; }

        public GetAllCoursesQuery(CourseSearchDto dto)
        {
            courseSearchDto = dto;
        }
        public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, PagedResponse<List<CourseDto>>>
        {
            private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
            private readonly IMapper _mapper;
            public GetAllCoursesHandler(IMapper mapper,
                ICourseReadOnlyRepository courseReadOnlyRepository)
            {
                _courseReadOnlyRepository = courseReadOnlyRepository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
            {
                var courseListResponse = await _courseReadOnlyRepository.GetAllAsync(request.courseSearchDto, cancellationToken);
                var courseDtos = _mapper.Map<List<CourseDto>>(courseListResponse.Value);

                return new PagedResponse<List<CourseDto>>
                {
                    Value = courseDtos,
                    IsSuccess = true,
                    TotalCount = courseListResponse.TotalCount
                };
            }
        }
    }
}
