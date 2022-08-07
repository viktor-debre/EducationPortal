using EducationPortal.Application.Interfaces.Repository;
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
            CreateUserCommandValidation validations = new CreateUserCommandValidation();
            ValidationResult validationResult = validations.Validate(newUser);
            if (!validationResult.IsValid)
            {
                return false;
            }

            _userRepository.GetUser();
            User? existingUser = _userRepository.GetUserByName(newUser.Name);
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
