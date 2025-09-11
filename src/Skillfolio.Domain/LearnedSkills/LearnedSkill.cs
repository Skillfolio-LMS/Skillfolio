using Skillfolio.Domain.LearnedSkills.Commands;
using Skillfolio.Domain.Skills;

namespace Skillfolio.Domain.LearnedSkills;

public class LearnedSkill
{
    // Primary Key
    public int Id { get; private set; }
    public int UserId { get; private set; }
    // Foreign Key
    public int SkillId { get; private set; }
    // Navigation Property
    public Skill Skill { get; private set; }
    public int ProficiencyLevel { get; private set;  }

    private LearnedSkill() {}

    public LearnedSkill(CreateLearnedSkillCommand command)
    {
        UserId = command.UserId;
        SkillId = command.SkillId;
        ProficiencyLevel = command.ProficiencyLevel;
    }
}