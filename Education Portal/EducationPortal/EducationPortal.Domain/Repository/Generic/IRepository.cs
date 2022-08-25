namespace EducationPortal.Domain.Repository
{
    public interface IRepository<TEntity>
    {
        public List<TEntity> Find();

        public TEntity FindById(int id);

        public void Add(TEntity item);

        public void Update(TEntity item);

        public void Remove(TEntity entity);
    }
}
