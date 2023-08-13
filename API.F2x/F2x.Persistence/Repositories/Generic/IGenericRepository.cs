
namespace Policy.PersonalSoft.Persistence.Repositories.Generic
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}
