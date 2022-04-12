using FluentValidation;


namespace PersonalProfilePersistence.Skills.ViewModels
{
    public class SkillViewModelsValidator : FluentValidation.AbstractValidator<SkillViewModels>
    {
        public SkillViewModelsValidator() : base()
        {
            RuleFor(current => current.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage(errorMessage: PersonalProfileResources.Messages.ErrorRequiredFluent)

                .MaximumLength(maximumLength: 10)
                .WithMessage(errorMessage: PersonalProfileResources.Messages.ErrorMaximumLength)
                ;

            RuleFor(current => current.Percent)
                .NotEmpty()
                .NotNull()
                .WithMessage(errorMessage: PersonalProfileResources.Messages.ErrorRequiredFluent)

                .GreaterThanOrEqualTo(0)
                .WithMessage(errorMessage: PersonalProfileResources.Messages.ErrorGreaterThanFluent)

                .LessThanOrEqualTo(100)
                .WithMessage(errorMessage: PersonalProfileResources.Messages.ErrorLessThanFluent)
                ;
        }
    }
}
