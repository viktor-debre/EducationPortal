using EducationPortal.Domain.Helpers.Specification;

namespace EducationPortal.Domain.Helpers.Repository
{
    public interface IRepository<TEntity>
    {
        public Task<List<TEntity>> Find(ISpecification<TEntity> specification = null);

        public Task<TEntity> FindById(int id);

        public Task Add(TEntity item);

        public Task Update(TEntity item);

        public Task Remove(TEntity entity);
    }
}
