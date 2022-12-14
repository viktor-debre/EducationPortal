using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Helpers.Specification;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands.CreateEntity
{
    internal class CreateUser
    {
        private readonly IRepository<User> _userRepository;

        public CreateUser(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> TryCreateUser(User newUser)
        {
            CreateUserValidation validations = new CreateUserValidation();
            ValidationResult validationResult = validations.Validate(newUser);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var userNameSpecification = new SpecificationBase<User>(x => x.Name == newUser.Name);
            var checkUser = await _userRepository.Find(userNameSpecification);
            if (checkUser.FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                _userRepository.Add(newUser);
                return true;
            }
        }
    }
}
