namespace EducationPortal.Domain.Repository
{
    public interface IRepository<TEntity>
    {
        public IEnumerable<TEntity> Find();

        public TEntity FindById(int id);

        public void Add(TEntity item);

        public void Update(TEntity item);

        public void Remove(TEntity entity);

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
