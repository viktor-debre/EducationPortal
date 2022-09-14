using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.UI.Models.Mapping;

namespace EducationPortal.UI.Services.Implementation
{
    public class SkillEditService : ISkillEditService
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillEditService(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        public List<SkillView> GetSkills()
        {
            List<SkillView> skills = new List<SkillView>();
            foreach (var skill in _skillService.GetSkills())
            {
                skills.Add(_mapper.MapSkillToViewModel(skill));
            }

            return skills;
        }

        public void SetSkill(SkillView skill)
        {
            _skillService.SetSkill(_mapper.MapSkillToDomainModel(skill));
        }

        public void RemoveSkill(SkillView skill)
        {
            _skillService.DeleteSkill(skill.Title);
        }

        public void UpdateSkill(SkillView skill)
        {
            var updatedSkill = _mapper.MapSkillToDomainModel(skill);
            _skillService.UpdateSkill(updatedSkill, updatedSkill);
        }

        public SkillView GetByIdSkill(int id)
        {
            return _mapper.MapSkillToViewModel(_skillService.GetSkillById(id));
        }
    }
}
