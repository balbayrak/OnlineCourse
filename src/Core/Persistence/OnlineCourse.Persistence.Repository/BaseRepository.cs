using OnlineCourse.Domain;

namespace OnlineCourse.Persistence.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : class, IEntity
    {
    }
}