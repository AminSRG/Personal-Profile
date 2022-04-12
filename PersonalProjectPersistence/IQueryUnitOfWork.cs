using PersonalProfilePersistence.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfilePersistence
{
    public interface IQueryUnitOfWork : Dtx.Persistence.IQueryUnitOfWork
    {
        public ISkillQueryRepository Skill { get; }
    }
}
