using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Exceptions;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Commands.Course
{
    public class UpdateCourseCommand : IRequest<ServiceResponse<CourseDto>>
    {
        public UpdateCourseDto updateCourseDto { get; set; }

        public UpdateCourseCommand(UpdateCourseDto dto)
        {
            updateCourseDto = dto;
        }

        public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ServiceResponse<CourseDto>>
        {
            private readonly ILogger<UpdateCourseCommand> _logger;
            private readonly ICourseRepository _courseRepository;
            private readonly IMapper _mapper;

            public UpdateCourseCommandHandler(ICourseRepository courseRepository,
                IMapper mapper,
                ILogger<UpdateCourseCommand> logger)
            {
                _courseRepository = courseRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ServiceResponse<CourseDto>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                var checkCourseExist = await _courseRepository.GetAsync(request.updateCourseDto.Id);
                if (checkCourseExist != null)
                {
                    checkCourseExist = _mapper.Map(request.updateCourseDto, checkCourseExist);
                    checkCourseExist = await _courseRepository.UpdateAsync(checkCourseExist, true);
                    var dto = _mapper.Map<CourseDto>(checkCourseExist);

               
                    return new ServiceResponse<CourseDto>
                    {
                        IsSuccess = true,
                        Value = dto
                    };
                }
                else
                {
                    _logger.LogInformation($"Course not found with Id:{request.updateCourseDto.Id}");

                    throw new CourseNotFoundException();
                }
            }
        }
    }
}
