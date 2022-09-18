using EducationPortal.Domain.Common;
using EducationPortal.Domain.Helpers.Repository;
using EducationPortal.Domain.Helpers.Specification;
using EducationPortal.Infrastructure.DB.Mapping;

namespace EducationPortal.Infrastructure.DB.Repository.Generic
{
    internal class EntityRepository<TEntity, TDbEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TDbEntity : DbBaseEntity
    {
        private readonly PortalContext _context;
        private readonly MapperForEntities _mapper;
        private readonly DbSet<TDbEntity> _dbSet;

        public EntityRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
            _dbSet = context.Set<TDbEntity>();
        }

        public async Task Remove(TEntity entity)
        {
            _dbSet.Remove((TDbEntity)await _mapper.MapToDbEntity(entity));
            await SaveAsync();
        }

        public async Task<List<TEntity>> Find(ISpecification<TEntity> specification = null)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (var entity in _dbSet)
            {
                entities.Add((TEntity)_mapper.MapToDomainEntity(entity));
            }

            List<TEntity> result;
            if (specification != null)
            {
                result = await entities.AsQueryable().Where(specification.Criteria).ToListAsync();
            }
            else
            {
                result = entities;
            }

            return result;
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync((TDbEntity)await _mapper.MapToDbEntity(entity));
            await SaveAsync();
        }

        public async Task Update(TEntity entity)
        {
            _context.Entry((TDbEntity)await _mapper.MapToDbEntity(entity)).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task<TEntity> FindById(int id)
        {
            return (TEntity)_mapper.MapToDomainEntity(await _dbSet.FindAsync(id));
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
