using EducationPortal.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
    public class UserInfoController : Controller
    {
        private readonly IUserInformationService _userInformation;

        public UserInfoController(IUserInformationService userInformation)
        {
            _userInformation = userInformation;
        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            var user = await _userInformation.GetUserInfo(User.Identity.Name);
            ViewBag.AuthorizedUser = user;
            var userSkills = user.UserSkills;
            List<SkillView> skills = new List<SkillView>();
            for (int i = 0; i < userSkills.Count; ++i)
            {
                SkillView? findedSkill = user.Skills.FirstOrDefault(x => x.Id == userSkills[i].SkillId);
                if (findedSkill != null)
                {
                    skills.Add(findedSkill);
                }
            }

            var userCourses = user.UserCourses;
            List<CourseView> courses = new List<CourseView>();
            for (int i = 0; i < userCourses.Count; ++i)
            {
                CourseView? findedCourse = user.Courses.FirstOrDefault(x => x.Id == userCourses[i].CourseId);
                if (findedCourse != null)
                {
                    courses.Add(findedCourse);
                }
            }

            ViewBag.UserSkills = skills;
            ViewBag.UserCourses = courses;
            return View();
        }
    }
}
