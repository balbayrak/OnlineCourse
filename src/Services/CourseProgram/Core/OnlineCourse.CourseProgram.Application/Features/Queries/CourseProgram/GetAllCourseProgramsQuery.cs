using AutoMapper;
using MediatR;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Queries.Course
{
    public class GetAllCourseProgramsQuery : IRequest<PagedResponse<List<CourseProgramDto>>>
    {
        public CourseProgramSearchDto courseProgramSearchDto { get; set; }

        public GetAllCourseProgramsQuery(CourseProgramSearchDto dto)
        {
            courseProgramSearchDto = dto;
        }
        public class GetAllCourseProgramsHandler : IRequestHandler<GetAllCourseProgramsQuery, PagedResponse<List<CourseProgramDto>>>
        {
            private readonly ICourseProgramReadOnlyRepository _courseProgramReadOnlyRepository;
            private readonly IMapper _mapper;
            public GetAllCourseProgramsHandler(IMapper mapper,
                ICourseProgramReadOnlyRepository courseProgramReadOnlyRepository)
            {
                _courseProgramReadOnlyRepository = courseProgramReadOnlyRepository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<List<CourseProgramDto>>> Handle(GetAllCourseProgramsQuery request, CancellationToken cancellationToken)
            {
                var courseProgramListResponse = await _courseProgramReadOnlyRepository.GetAllAsync(request.courseProgramSearchDto, cancellationToken);
                var courseProgramDtos = _mapper.Map<List<CourseProgramDto>>(courseProgramListResponse.Value);

                return new PagedResponse<List<CourseProgramDto>>
                {
                    Value = courseProgramDtos,
                    IsSuccess = true,
                    TotalCount = courseProgramListResponse.TotalCount
                };
            }
        }
    }
}
