namespace PersonalProfileApplication.Skill.Commands
{
    public class CreateSkillCommand : SkillCommand, Dtx.Mediator.IRequest
    {
        public CreateSkillCommand(int iD, string title, byte percent)
                                           : base(iD: iD, title: title, percent: percent)
        {

        }
    }
}
