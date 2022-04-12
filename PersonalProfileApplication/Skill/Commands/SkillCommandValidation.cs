using FluentValidation;

namespace PersonalProfileApplication.Skill.Commands
{
    public class SkillCommandValidation : FluentValidation.AbstractValidator<SkillCommand>
    {
        public SkillCommandValidation() : base()
        {
            RuleFor(current => current.Title)
                .NotEmpty()
                .WithMessage(errorMessage: PersonalProfileResources.Messages.ErrorRequiredFluent)

                .MaximumLength(maximumLength: 10)
                .WithMessage(errorMessage: PersonalProfileResources.Messages.ErrorMaximumLength)
                ;
        }
    }
}
