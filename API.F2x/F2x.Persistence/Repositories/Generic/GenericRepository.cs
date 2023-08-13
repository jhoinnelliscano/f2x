using Policy.PersonalSoft.Persistence.Context;

namespace Policy.PersonalSoft.Persistence.Repositories.Generic
{
    public class GenericRepository<TEntity> where TEntity : class//, IGenericRepository<TEntity>
    {
        internal InsuranceDbContext context;
        public GenericRepository(InsuranceDbContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<TEntity> GetAll() 
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetByField(Dictionary<string,string> search)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById()
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(TEntity entity)
        {
        }

        public virtual void Update(TEntity entity)
        {
        }

        public virtual void Delete(TEntity entity)
        {
        }
    }
}
