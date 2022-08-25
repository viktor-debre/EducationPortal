using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    internal class CreateUser
    {
        private readonly IRepository<User> _userRepository;

        public CreateUser(IRepository<User> userRepository)
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

            var checkUser = _userRepository.Find().FirstOrDefault(x => x.Name == newUser.Name);
            if (checkUser != null)
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
