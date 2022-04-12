using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfileApplication.Skill.Queries
{
    public class SkillQuery : object,
        Dtx.Mediator.IRequest
        <PersonalProfilePersistence.Skills.ViewModels.SkillViewModels>
    {
        public SkillQuery() : base()
        {
        }

        public int ID { get; set; }
    }
}
