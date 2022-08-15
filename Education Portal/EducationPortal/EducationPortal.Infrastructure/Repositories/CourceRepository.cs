using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class CourceRepository : ICourseRepository
    {
        private const string CoursePath = @"D:\work\course.json";

        private readonly StorageManager<Course> _storage = new StorageManager<Course>();

        public CourceRepository()
        {
            Courses = new List<Course>();
        }

        public List<Course> Courses { get; set; }

        public bool DeleteCourse(string name)
        {
            var course = GetCourceById(name);
            if (course != null)
            {
                Courses.Remove(course);
                _storage.AddItemToStorage(Courses, CoursePath);
                return true;
            }

            return false;
        }

        public Course? GetCourceById(string name)
        {
            return Courses.FirstOrDefault(x => x.Name == name);
        }

        public List<Course> GetCources()
        {
            List<Course> courses = _storage.ExctractItemsFromStorage(CoursePath);
            if (courses != null)
            {
                Courses = courses;
            }

            return Courses;
        }

        public void SetCourse(Course cource)
        {
            Courses.Add(cource);
            _storage.AddItemToStorage(Courses, CoursePath);
        }

        public void UpdateCourse(string name, Course updatedMaterial)
        {
            if (DeleteCourse(name))
            {
                SetCourse(updatedMaterial);
            }
        }

        public void AddMaterial(string name, Material material)
        {
            GetCources();
            var course = GetCourceById(name);
            if (course != null)
            {
                course.Materials.Add(material);
                UpdateCourse(name, course);
            }
        }

        public Course? GetCourceById(int id)
        {
            throw new NotImplementedException();
        }

        void ICourseRepository.DeleteCourse(string name)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
