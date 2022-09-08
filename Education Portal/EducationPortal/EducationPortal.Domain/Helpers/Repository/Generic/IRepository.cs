using EducationPortal.Domain.Helpers.Specification;

namespace EducationPortal.Domain.Helpers.Repository
{
    public interface IRepository<TEntity>
    {
        public List<TEntity> Find(ISpecification<TEntity> specification = null);

        public TEntity FindById(int id);

        public void Add(TEntity item);

        public void Update(TEntity item);

        public void Remove(TEntity entity);
    }
}
