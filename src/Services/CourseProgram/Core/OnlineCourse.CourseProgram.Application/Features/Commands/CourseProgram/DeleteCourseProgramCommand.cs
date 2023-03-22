using MediatR;
using Microsoft.Extensions.Logging;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Exceptions;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Commands.Course
{
    public class DeleteCourseProgramCommand : IRequest<ServiceResponse<bool>>
    {
        public DeleteCourseProgramDto deleteCourseProgramDto { get; set; }

        public DeleteCourseProgramCommand(DeleteCourseProgramDto dto)
        {
            deleteCourseProgramDto = dto;
        }
        public class DeleteCourseProgramCommandHandler : IRequestHandler<DeleteCourseProgramCommand, ServiceResponse<bool>>
        {
            private readonly ILogger<DeleteCourseProgramCommand> _logger;
            private readonly ICourseProgramRepository _courseProgramRepository;

            public DeleteCourseProgramCommandHandler(ICourseProgramRepository courseProgramRepository, ILogger<DeleteCourseProgramCommand> logger)
            {
                _courseProgramRepository = courseProgramRepository;
                _logger = logger;
            }

            public async Task<ServiceResponse<bool>> Handle(DeleteCourseProgramCommand request, CancellationToken cancellationToken)
            {
              
                var checkCourseProgramExist = await _courseProgramRepository.GetAsync(request.deleteCourseProgramDto.Id);
                if (checkCourseProgramExist != null)
                {
                    await _courseProgramRepository.DeleteAsync(request.deleteCourseProgramDto.Id, true);

                    return new ServiceResponse<bool>
                    {
                        IsSuccess = true,
                        Value = true
                    };
                }
                else
                {
                    _logger.LogInformation($"CourseProgram not found with Id:{request.deleteCourseProgramDto.Id}");

                    throw new CourseProgramNotFoundException();
                }
            }
        }
    }
}
