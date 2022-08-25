namespace EducationPortal.Domain.Repository
{
    public interface IRepository<TEntity>
    {
        public IEnumerable<TEntity> Find();

        public TEntity FindById(int id);

        public void Add(TEntity item);

        public void Update(TEntity item);

        public void Remove(TEntity entity);
    }
}
