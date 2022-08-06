using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities;
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


            List<User> users = _userRepository.ReadUserFromStorage();
            if (users == null)
            {
                
                _userRepository.SetUserInStorage(newUser);
                return true;
            }
            User? existingUser = users.FirstOrDefault(u => u.Name == newUser.Name, null);
            if (existingUser != null)
            {
                return false;
            }
            else
            {
                _userRepository.SetUserInStorage(newUser);
                return true;
            }
        }
    }
}
