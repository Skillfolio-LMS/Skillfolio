using FluentValidation;

namespace Skillfolio.Domain.LearnedSkills.Commands;

public class CreateLearnedSkillCommandValidator : AbstractValidator<CreateLearnedSkillCommand>
{
    public CreateLearnedSkillCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be greater than 0.");
        
        RuleFor(x => x.SkillId)
            .GreaterThan(0)
            .WithMessage("SkillId must be greater than 0.");
        
        RuleFor(x => x.ProficiencyLevel)
            .InclusiveBetween(1, 5)
            .WithMessage("ProficiencyLevel must be between 1 and 5.");
    }
}