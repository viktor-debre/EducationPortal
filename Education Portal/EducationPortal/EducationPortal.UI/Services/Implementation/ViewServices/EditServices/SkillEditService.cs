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

        public async Task<List<SkillView>> GetSkills()
        {
            List<SkillView> skills = new List<SkillView>();
            foreach (var skill in await _skillService.GetSkills())
            {
                skills.Add(_mapper.MapSkillToViewModel(skill));
            }

            return skills;
        }

        public async Task SetSkill(SkillView skill)
        {
            await _skillService.SetSkill(_mapper.MapSkillToDomainModel(skill));
        }

        public async Task RemoveSkill(SkillView skill)
        {
            var neededSkill = _mapper.MapSkillToDomainModel(skill);
            await _skillService.DeleteSkill(neededSkill);
        }

        public async Task UpdateSkill(SkillView skill)
        {
            var updatedSkill = _mapper.MapSkillToDomainModel(skill);
            await _skillService.UpdateSkill(updatedSkill);
        }

        public async Task<SkillView>? GetByIdSkill(int id)
        {
            var skill = await _skillService.GetSkillById(id);
            return skill is not null ? _mapper.MapSkillToViewModel(skill) : null;
        }
    }
}
