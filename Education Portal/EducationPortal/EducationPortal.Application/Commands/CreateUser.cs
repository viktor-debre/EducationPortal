using EducationPortal.Application.Commands.Validation;
using EducationPortal.Domain.Repository;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool TryCreateUser(User newUser)
        {
            CreateUserValidation validations = new CreateUserValidation();
            ValidationResult validationResult = validations.Validate(newUser);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var idOfUser = _userRepository.GetUsers().FirstOrDefault(x => x.Name == newUser.Name).Id;
            User? existingUser = _userRepository.GetUserById(idOfUser);
            if (existingUser != null)
            {
                return false;
            }
            else
            {
                _userRepository.SetUser(newUser);
                return true;
            }
        }
    }
}
