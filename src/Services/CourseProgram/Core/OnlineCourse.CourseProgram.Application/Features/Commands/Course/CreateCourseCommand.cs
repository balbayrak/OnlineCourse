using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Commands.Course
{
    public class CreateCourseCommand : IRequest<ServiceResponse<Guid>>
    {
        public CreateCourseDto createCourseDto { get; set; }

        public CreateCourseCommand(CreateCourseDto dto)
        {
            createCourseDto = dto;
        }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ServiceResponse<Guid>>
        {
            private readonly ILogger<CreateCourseCommand> _logger;
            private readonly ICourseRepository _courseRepository;
            private readonly IMapper _mapper;
            public CreateCourseCommandHandler(ICourseRepository courseRepository,
                IMapper mapper,
                ILogger<CreateCourseCommand> logger)
            {
                _courseRepository = courseRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = _mapper.Map<Domain.Models.Course>(request.createCourseDto);
                course = await _courseRepository.InsertAsync(course, true);

                return new ServiceResponse<Guid>
                {
                    IsSuccess = true,
                    Value = course.Id
                };
            }
        }
    }
}
