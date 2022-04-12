namespace PersonalProfileApplication.Skill.Commands
{
    public class DeleteSkillCommand : SkillCommand, Dtx.Mediator.IRequest
    {
        public DeleteSkillCommand(int iD, string title, byte percent)
                                           : base(iD: iD, title: title, percent: percent)
        {

        }
    }
}
