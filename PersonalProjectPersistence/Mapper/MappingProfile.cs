using AutoMapper;
using PersonalProfileDomain.Entitys;
using PersonalProfilePersistence.Skills.ViewModels;

namespace PersonalProfilePersistence.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<Skill, SkillViewModels>();
            CreateMap<SkillViewModels, Skill>();
        }
    }
}