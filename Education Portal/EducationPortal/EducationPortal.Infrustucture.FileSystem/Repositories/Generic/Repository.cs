using EducationPortal.Domain.Common;
using EducationPortal.Domain.Helpers.Repository;
using EducationPortal.Domain.Helpers.Specification;

namespace EducationPortal.Infrustucture.FileSystem.Repositories.Generic
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly StorageManager<TEntity> _storage = new StorageManager<TEntity>();

        public Repository()
        {
            PathToEntity = GetPathToEntity();
            EntitiesList = new List<TEntity>();
        }

        public string PathToEntity { get; set; }

        public List<TEntity> EntitiesList { get; set; }

        public void Add(TEntity item)
        {
            EntitiesList.Add(item);
            _storage.AddItemToStorage(EntitiesList, PathToEntity);
        }

        public List<TEntity> Find(ISpecification<TEntity> specification = null)
        {
            List<TEntity> materials = _storage.ExctractItemsFromStorage(PathToEntity);
            if (materials != null)
            {
                EntitiesList = materials;
            }

            List<TEntity> result;
            if (specification != null)
            {
                result = EntitiesList.AsQueryable().Where(specification.Criteria).ToList();
            }
            else
            {
                result = EntitiesList;
            }

            return result;
        }

        public TEntity? FindById(int id)
        {
            return EntitiesList.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(TEntity entity)
        {
            var item = FindById(entity.Id);
            if (item != null)
            {
                EntitiesList.Remove(item);
                _storage.AddItemToStorage(EntitiesList, PathToEntity);
            }
        }

        public void Update(TEntity item)
        {
            TEntity? oldItem = FindById(item.Id);
            if (oldItem != null)
            {
                Remove(oldItem);
                Add(item);
            }
        }

        private string GetPathToEntity()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
            string fileStorageLevel = @"\EducationPortal.Infrustucture.FileSystem\JsonFiles\";
            Type type = typeof(TEntity);
            string nameEntity = type.Name;
            string pathToEntityStorage = projectDirectory + fileStorageLevel + nameEntity + ".json";
            if (!File.Exists(pathToEntityStorage))
            {
                File.Create(pathToEntityStorage);
            }

            return pathToEntityStorage;
        }
    }
}
