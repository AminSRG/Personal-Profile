using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProfileApplication.Skill.Commands
{
    public class SkillCommand
    {
        public SkillCommand()
        {
        }

        public SkillCommand(int iD, string title, byte percent)
        {
            ID = iD;
            Title = title;
            Percent = percent;
        }

        public int ID { get; set; }
		public string Title { get; set; }
		public byte Percent { get; set; }
	}
}
