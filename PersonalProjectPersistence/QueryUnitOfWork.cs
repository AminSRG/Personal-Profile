using PersonalProfilePersistence.Context;
using PersonalProfilePersistence.Skills.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfilePersistence
{
    public class QueryUnitOfWork :
        Dtx.Persistence.QueryUnitOfWork<EntityContext>, IQueryUnitOfWork
    {
        public QueryUnitOfWork
    (Dtx.Persistence.Options options) : base(options: options)
        {
        }


        // **************************************************
        private ISkillQueryRepository _skill;

        public ISkillQueryRepository Skill
        {
            get
            {
                if (_skill == null)
                {
                    _skill =
                        new SkillQueryRepository(databaseContext: DatabaseContext);
                }

                return _skill;
            }
        }
        // **************************************************
    }
}
