namespace PersonalProfileApplication.Skill.Commands
{
    public class UpdateSkillCommand : SkillCommand, Dtx.Mediator.IRequest
    {
        public UpdateSkillCommand(int iD, string title, byte percent)
                                           : base(iD: iD, title: title, percent: percent)
        {

        }
    }
}
