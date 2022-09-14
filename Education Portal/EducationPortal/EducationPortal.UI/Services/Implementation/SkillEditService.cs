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
    }
}
