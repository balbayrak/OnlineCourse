using AutoMapper;
using MediatR;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Queries.Course
{
    public class GetByIdCourseProgramQuery : IRequest<ServiceResponse<CourseProgramDto>>
    {
        public Guid CourseProgramId { get; set; }

        public GetByIdCourseProgramQuery(Guid Id)
        {
            CourseProgramId =  Id;
        }
        public class GetByIdCourseProgramHandler : IRequestHandler<GetByIdCourseProgramQuery, ServiceResponse<CourseProgramDto>>
        {
            private readonly ICourseProgramReadOnlyRepository _courseProgramReadOnlyRepository;
            private readonly IMapper _mapper;
            public GetByIdCourseProgramHandler(IMapper mapper,
                ICourseProgramReadOnlyRepository courseProgramReadOnlyRepository)
            {
                _mapper = mapper;
                _courseProgramReadOnlyRepository = courseProgramReadOnlyRepository;
            }
            public async Task<ServiceResponse<CourseProgramDto>> Handle(GetByIdCourseProgramQuery request, CancellationToken cancellationToken)
            {
                var courseProgram = await _courseProgramReadOnlyRepository.GetAsync(request.CourseProgramId, cancellationToken);
                var courseProgramDto = _mapper.Map<CourseProgramDto>(courseProgram);

                return new ServiceResponse<CourseProgramDto>
                {
                    Value = courseProgramDto,
                    IsSuccess = true
                };
            }
        }
    }
}
