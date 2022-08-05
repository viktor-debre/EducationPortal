using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.Domain.Entities;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    public class CreateUser
    {
        IUserCRUD _usersCRUD;

        public CreateUser(IUserCRUD userCRUD)
        {
            _usersCRUD = userCRUD;
        }

        public bool TryCreateUser(User newUser)
        {
            CreateUserCommandValidation validations = new CreateUserCommandValidation();
            ValidationResult validationResult = validations.Validate(newUser);
            if (!validationResult.IsValid)
            {
                return false;
            }
            if (_usersCRUD.ReadUserFromStorage().First(u => u.Name == newUser.Name).Name == newUser.Name)
            {
                return false;
            }
            _usersCRUD.SetUserInStorage(newUser);
            return true;
        }
    }
}
