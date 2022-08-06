﻿using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities;
using FluentValidation.Results;

namespace EducationPortal.Application.Commands
{
    public class CreateUser
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
            _userRepository.ReadUserFromStorage();
            List<User>? users = _userRepository.Users;
            User? existingUser = users.FirstOrDefault(u => u.Name == newUser.Name);
            if (existingUser.Name == newUser.Name)
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
