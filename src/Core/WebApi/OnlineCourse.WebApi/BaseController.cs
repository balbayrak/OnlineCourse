using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace OnlineCourse.WebApi
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; private set; }

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
