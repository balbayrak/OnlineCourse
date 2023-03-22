using AutoMapper;
using MediatR;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Queries.Course
{
    public class GetByIdCourseQuery : IRequest<ServiceResponse<CourseDto>>
    {
        public Guid CourseId { get; set; }

        public GetByIdCourseQuery(Guid Id)
        {
            CourseId =  Id;
        }
        public class GetByIdCourseHandler : IRequestHandler<GetByIdCourseQuery, ServiceResponse<CourseDto>>
        {
            private readonly ICourseReadOnlyRepository _courseReadOnlyRepository;
            private readonly IMapper _mapper;
            public GetByIdCourseHandler(IMapper mapper,
                ICourseReadOnlyRepository courseReadOnlyRepository)
            {
                _mapper = mapper;
                _courseReadOnlyRepository = courseReadOnlyRepository;
            }
            public async Task<ServiceResponse<CourseDto>> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
            {
                var course = await _courseReadOnlyRepository.GetAsync(request.CourseId, cancellationToken);
                var courseDto = _mapper.Map<CourseDto>(course);

                return new ServiceResponse<CourseDto>
                {
                    Value = courseDto,
                    IsSuccess = true
                };
            }
        }
    }
}
