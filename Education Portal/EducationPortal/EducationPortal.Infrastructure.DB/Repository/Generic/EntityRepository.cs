using EducationPortal.Domain.Repository;
using System.Linq.Expressions;

namespace EducationPortal.Infrastructure.DB.Repository.Generic
{
    internal class EntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : DbBaseEntity
    {
        private readonly PortalContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EntityRepository(PortalContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Find()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Add(TEntity item)
        {
            _context.Add(item);
            Save();
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
            Save();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            Save();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
