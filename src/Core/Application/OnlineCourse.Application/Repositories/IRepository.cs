using OnlineCourse.Application.Dto;
using OnlineCourse.Application.Wrappers;
using OnlineCourse.Domain;
using System.Linq.Expressions;

namespace OnlineCourse.Application.Repositories
{
    public interface IRepository<TEntity, TSearchDto> : ICommandRepository<TEntity>, IReadOnlyRepository<TEntity, TSearchDto>
       where TEntity : class, IEntity
       where TSearchDto : PagedSearchDto
    {
    }
}
