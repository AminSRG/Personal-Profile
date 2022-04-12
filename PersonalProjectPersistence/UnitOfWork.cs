using PersonalProfilePersistence.Context;
using PersonalProfilePersistence.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfilePersistence
{
    public class UnitOfWork :
        Dtx.Persistence.UnitOfWork<EntityContext>, IUnitOfWork
    {
        public UnitOfWork
                 (Dtx.Persistence.Options options) : base(options: options)
        {
        }

        // **************************************************
        private ISkillRepository _skill;

        public ISkillRepository Skill
        {
            get
            {
                if (_skill == null)
                {
                    _skill =
                        new SkillRepository(databaseContext: DatabaseContext);
                }

                return _skill;
            }
        }
        // **************************************************
    }
}
