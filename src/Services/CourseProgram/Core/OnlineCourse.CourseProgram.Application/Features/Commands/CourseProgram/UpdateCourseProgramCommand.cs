using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Exceptions;
using OnlineCourse.CourseProgram.Application.Repositories.Course;

namespace OnlineCourse.CourseProgram.Application.Features.Commands.Course
{
    public class UpdateCourseProgramCommand : IRequest<ServiceResponse<CourseProgramDto>>
    {
        public UpdateCourseProgramDto updateCourseProgramDto { get; set; }

        public UpdateCourseProgramCommand(UpdateCourseProgramDto dto)
        {
            updateCourseProgramDto = dto;
        }

        public class UpdateCourseProgramCommandHandler : IRequestHandler<UpdateCourseProgramCommand, ServiceResponse<CourseProgramDto>>
        {
            private readonly ILogger<UpdateCourseCommand> _logger;
            private readonly ICourseProgramRepository _courseProgramRepository;
            private readonly IMapper _mapper;

            public UpdateCourseProgramCommandHandler(ICourseProgramRepository courseProgramRepository,
                IMapper mapper,
                ILogger<UpdateCourseCommand> logger)
            {
                _courseProgramRepository = courseProgramRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<ServiceResponse<CourseProgramDto>> Handle(UpdateCourseProgramCommand request, CancellationToken cancellationToken)
            {
                var checkCourseProgramExist = await _courseProgramRepository.GetAsync(request.updateCourseProgramDto.Id,cancellationToken);
                if (checkCourseProgramExist != null)
                {
                    checkCourseProgramExist = _mapper.Map(request.updateCourseProgramDto, checkCourseProgramExist);
                    checkCourseProgramExist = await _courseProgramRepository.UpdateAsync(checkCourseProgramExist, true);
                    var dto = _mapper.Map<CourseProgramDto>(checkCourseProgramExist);

               
                    return new ServiceResponse<CourseProgramDto>
                    {
                        IsSuccess = true,
                        Value = dto
                    };
                }
                else
                {
                    _logger.LogInformation($"CourseProgram not found with Id:{request.updateCourseProgramDto.Id}");

                    throw new CourseProgramNotFoundException();
                }
            }
        }
    }
}
