using AutoMapper;
using MediatR;
using OnlineCourse.Application.Dto;
using OnlineCourse.Application.Repositories;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.Domain;

namespace OnlineCourse.Application.Features.Commands
{
    public abstract class BaseCommandHandler<TEntity, TDto, TCreateCommand, TRepository> : IRequestHandler<TCreateCommand, ServiceResponse<TDto>>
        where TEntity : class, IEntity
        where TDto : class
        where TRepository : ICommandRepository<TEntity>
        where TCreateCommand : BaseCommand<TDto>
    {
        protected readonly TRepository Repository;
        protected readonly IMapper Mapper;

        public BaseCommandHandler(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public abstract Task<ServiceResponse<TDto>> HandleCommand(TCreateCommand request, CancellationToken cancellationToken);

        public async Task<ServiceResponse<TDto>> Handle(TCreateCommand request, CancellationToken cancellationToken)
        {
            return await HandleCommand(request, cancellationToken);
        }
    }
}
