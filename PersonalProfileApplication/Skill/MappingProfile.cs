namespace PersonalProfileApplication.Skill
{
    public class MappingProfile : PersonalProfilePersistence.Mapper.MappingProfile
    {
        public MappingProfile() : base()
        {
            CreateMap<Commands.CreateSkillCommand, PersonalProfileDomain.Entitys.Skill>();
            CreateMap<PersonalProfileDomain.Entitys.Skill, Commands.CreateSkillCommand>();

            CreateMap<Commands.UpdateSkillCommand, PersonalProfileDomain.Entitys.Skill>();
            CreateMap<PersonalProfileDomain.Entitys.Skill, Commands.UpdateSkillCommand>();

            CreateMap<Commands.DeleteSkillCommand, PersonalProfileDomain.Entitys.Skill>();
            CreateMap<PersonalProfileDomain.Entitys.Skill, Commands.DeleteSkillCommand>();
        }
    }
}
