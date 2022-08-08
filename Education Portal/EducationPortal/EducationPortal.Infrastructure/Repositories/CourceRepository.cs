using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class CourceRepository : ICourseRepository
    {
        public List<Course> Courses { get; set; }
        private const string coursePath = @"D:\work\book.json";
        private readonly StorageManager<Course> _storage = new StorageManager<Course>();

        public CourceRepository()
        {
            Courses = new List<Course>();
        }

        public bool DeleteCourse(string name)
        {
            var course = GetCourceByName(name);
            if (course != null)
            {
                Courses.Remove(course);
                _storage.AddItemToStorage(Courses, coursePath);
                return true;
            }
            return false;
        }

        public Course? GetCourceByName(string name)
        {
            return Courses.FirstOrDefault(x => x.Name == name);
        }

        public List<Course> GetCources()
        {
            List<Course> courses = _storage.ExctractItemsFromStorage(coursePath);
            if (courses != null)
            {
                Courses = courses;
            }
            return Courses;
        }

        public void SetCourse(Course cource)
        {
            Courses.Add(cource);
            _storage.AddItemToStorage(Courses, coursePath);
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
            var course = GetCourceByName(name);
            if (course != null)
            {
                course.Matherials.Add(material);
                UpdateCourse(name, course);
            }
        }
    }
}
