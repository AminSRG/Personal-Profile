using PersonalProfileDomain.Entitys;

namespace PersonalProfilePersistence.Skills.Repositories
{
    public class SkillRepository :
        Dtx.Persistence.Repository<Skill>, ISkillRepository
    {
        protected internal SkillRepository
    (Microsoft.EntityFrameworkCore.DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
