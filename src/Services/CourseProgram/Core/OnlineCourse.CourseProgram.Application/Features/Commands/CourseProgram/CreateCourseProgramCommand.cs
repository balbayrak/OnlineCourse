using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Commands.Course
{
    public class CreateCourseProgramCommand : IRequest<ServiceResponse<Guid>>
    {
        public CreateCourseProgramDto createCourseProgramDto { get; set; }

        public CreateCourseProgramCommand(CreateCourseProgramDto dto)
        {
            createCourseProgramDto = dto;
        }

        public class CreateCourseProgramCommandHandler : IRequestHandler<CreateCourseProgramCommand, ServiceResponse<Guid>>
        {
            private readonly ILogger<CreateCourseCommand> _logger;
            private readonly ICourseProgramRepository _courseProgramRepository;
            private readonly IMapper _mapper;
            public CreateCourseProgramCommandHandler(ICourseProgramRepository courseProgramRepository,
                IMapper mapper,
                ILogger<CreateCourseCommand> logger)
            {
                _courseProgramRepository = courseProgramRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateCourseProgramCommand request, CancellationToken cancellationToken)
            {
                var courseProgram = _mapper.Map<Domain.Models.CourseProgram>(request.createCourseProgramDto);
                courseProgram = await _courseProgramRepository.InsertAsync(courseProgram, true);

                return new ServiceResponse<Guid>
                {
                    IsSuccess = true,
                    Value = courseProgram.Id
                };
            }
        }
    }
}
