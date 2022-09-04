﻿namespace EducationPortal.Application.Services
{
    internal class UserInfoService : IUserInfoService
    {
        private readonly IRepository<User> _userRepository;

        public UserInfoService(IRepository<User> userSkillRepository)
        {
            _userRepository = userSkillRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.FindById(id);
        }
    }
}