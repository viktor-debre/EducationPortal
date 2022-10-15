using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Helpers.Specification;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands.CreateEntity
{
    internal class CreateCourse
    {
        private readonly IRepository<Course> _courseRepository;

        public CreateCourse(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> TryCreateCorse(Course course)
        {
            CreateCourseValidation validations = new CreateCourseValidation();
            ValidationResult validationResult = validations.Validate(course);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var courseNameSpecification = new SpecificationBase<Course>(x => x.Name == course.Name);
            var checkCourse = await _courseRepository.Find(courseNameSpecification);
            if (checkCourse.FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                await _courseRepository.Add(course);
                return true;
            }
        }
    }
}
