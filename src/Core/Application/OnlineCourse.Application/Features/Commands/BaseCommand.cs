using MediatR;
using OnlineCourse.Application.Common;
using OnlineCourse.Application.Wrappers;

namespace OnlineCourse.Application.Features.Commands
{
    public class BaseCommand<TDto> : IRequest<ServiceResponse<TDto>>
        where TDto : class

    {
        public TDto Dto { get; set; }
        public BaseCommand(TDto dto)
        {
            Dto = dto;
        }

        public BaseCommand(TDto dto,Guid correlationId)
        {
            Dto = dto;
        }
    }

}
