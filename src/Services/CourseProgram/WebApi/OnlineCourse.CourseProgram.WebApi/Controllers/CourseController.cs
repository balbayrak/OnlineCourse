using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.CourseProgram.Application.Dto.Course;
using OnlineCourse.CourseProgram.Application.Features.Commands.Course;
using OnlineCourse.CourseProgram.Application.Features.Queries.Course;
using OnlineCourse.WebApi;
using OnlineCourse.WebApi.Attributes;
using System.Net;

namespace OnlineCourse.CourseProgram.WebApi.Controllers
{
    [ApiController]
    public class CourseController : BaseController
    {
        public CourseController(IMediator mediator) : base(mediator)
        {
        }

      //  [Cached(1800)]
        [HttpGet]
        [Route("api/[controller]/all")]
        [ProducesResponseType(typeof(PagedResponse<List<CourseDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCourses([FromQuery] CourseSearchDto courseSearchDto)
        {
            var query = new GetAllCoursesQuery(courseSearchDto);
            return Ok(await Mediator.Send(query));
        }

     //   [Cached(1800)]
        [HttpGet]
        [Route("api/[controller]/read")]
        [ProducesResponseType(typeof(ServiceResponse<CourseDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(Guid courseId)
        {
            var query = new GetByIdCourseQuery(courseId);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("api/[controller]/create")]
        [ProducesResponseType(typeof(ServiceResponse<Guid>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Create(CreateCourseDto createCourseDto)
        {
            var command = new CreateCourseCommand(createCourseDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/update")]
        public async Task<IActionResult> Update(UpdateCourseDto updateCourseDto)
        {
            var query = new UpdateCourseCommand(updateCourseDto);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("api/[controller]/delete")]
        public async Task<IActionResult> Delete(Guid courseId)
        {
            var query = new DeleteCourseCommand(new DeleteCourseDto
            {
                Id = courseId
            });
            return Ok(await Mediator.Send(query));
        }
    }
}
