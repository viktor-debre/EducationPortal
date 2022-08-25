using EducationPortal.Domain.Common;
using EducationPortal.Domain.Repository;
using System.Linq.Expressions;

namespace EducationPortal.Infrastructure.DB.Repository.Generic
{
    internal class EntityRepository<TEntity, TDbEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TDbEntity : DbBaseEntity
    {
        private readonly PortalContext _context;
        private readonly MapToDbModels _mapper;
        private readonly DbSet<TDbEntity> _dbSet;

        public EntityRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapToDbModels(context);
            _dbSet = context.Set<TDbEntity>();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove((TDbEntity)_mapper.MapToDbEntity(entity));
            Save();
        }

        public List<TEntity> Find()
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (var entity in _dbSet)
            {
                entities.Add((TEntity)_mapper.MapToDomainEntity(entity));
            }

            return entities;
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add((TDbEntity)_mapper.MapToDbEntity(entity));
            Save();
        }

        public void Update(TEntity entity)
        {
            _context.Entry((TDbEntity)_mapper.MapToDbEntity(entity)).State = EntityState.Modified;
            Save();
        }

        public TEntity FindById(int id)
        {
            return (TEntity)_mapper.MapToDomainEntity(_dbSet.Find(id));
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
