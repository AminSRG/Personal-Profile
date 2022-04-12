using PersonalProfileDomain.Entitys;
using PersonalProfilePersistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfilePersistence.Skills.Repositories
{
    public class SkillQueryRepository :
        Dtx.Persistence.QueryRepository<Skill>, ISkillQueryRepository
    {
        public SkillQueryRepository(EntityContext databaseContext) : base(databaseContext)
        {
        }
    }
}
