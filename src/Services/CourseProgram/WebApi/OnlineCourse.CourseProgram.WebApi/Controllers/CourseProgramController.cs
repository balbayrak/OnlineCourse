using MediatR;
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
    public class CourseProgramController : BaseController
    {
        public CourseProgramController(IMediator mediator) : base(mediator)
        {
        }

       // [Cached(1800)]
        [HttpGet]
        [Route("api/[controller]/all")]
        [ProducesResponseType(typeof(PagedResponse<List<CourseProgramDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCoursePrograms([FromQuery] CourseProgramSearchDto courseProgramSearchDto)
        {
            var query = new GetAllCourseProgramsQuery(courseProgramSearchDto);
            return Ok(await Mediator.Send(query));
        }

       // [Cached(1800)]
        [HttpGet]
        [Route("api/[controller]/read")]
        [ProducesResponseType(typeof(ServiceResponse<CourseProgramDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(Guid courseProgramId)
        {
            var query = new GetByIdCourseProgramQuery(courseProgramId);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("api/[controller]/create")]
        [ProducesResponseType(typeof(ServiceResponse<Guid>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Create(CreateCourseProgramDto createCourseProgramDto)
        {
            var command = new CreateCourseProgramCommand(createCourseProgramDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/[controller]/update")]
        public async Task<IActionResult> Update(UpdateCourseProgramDto updateCourseProgramDto)
        {
            var query = new UpdateCourseProgramCommand(updateCourseProgramDto);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("api/[controller]/delete")]
        public async Task<IActionResult> Delete(Guid courseProgramId)
        {
            var query = new DeleteCourseProgramCommand(new DeleteCourseProgramDto
            {
                Id = courseProgramId
            });
            return Ok(await Mediator.Send(query));
        }
    }
}
