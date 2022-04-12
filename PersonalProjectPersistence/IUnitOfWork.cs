using PersonalProfilePersistence.Skills.Repositories;

namespace PersonalProfilePersistence
{
    public interface IUnitOfWork : Dtx.Persistence.IUnitOfWork
    {
        public ISkillRepository Skill { get;}
    }
}
