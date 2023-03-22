using MediatR;
using Microsoft.Extensions.Logging;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Exceptions;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Commands.Course
{
    public class DeleteCourseCommand : IRequest<ServiceResponse<bool>>
    {
        public DeleteCourseDto deleteCourseDto { get; set; }

        public DeleteCourseCommand(DeleteCourseDto dto)
        {
            deleteCourseDto = dto;
        }
        public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ServiceResponse<bool>>
        {
            private readonly ILogger<DeleteCourseCommand> _logger;
            private readonly ICourseRepository _courseRepository;

            public DeleteCourseCommandHandler(ICourseRepository courseRepository, ILogger<DeleteCourseCommand> logger)
            {
                _courseRepository = courseRepository;
                _logger = logger;
            }

            public async Task<ServiceResponse<bool>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
            {
              
                var checkCourseExist = await _courseRepository.GetAsync(request.deleteCourseDto.Id);
                if (checkCourseExist != null)
                {
                    await _courseRepository.DeleteAsync(request.deleteCourseDto.Id, true);

                    return new ServiceResponse<bool>
                    {
                        IsSuccess = true,
                        Value = true
                    };
                }
                else
                {
                    _logger.LogInformation($"Course not found with courseId:{request.deleteCourseDto.Id}");

                    throw new CourseNotFoundException();
                }
            }
        }
    }
}
