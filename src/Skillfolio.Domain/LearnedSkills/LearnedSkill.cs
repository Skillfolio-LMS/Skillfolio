using Skillfolio.Domain.LearnedSkills.Commands;

namespace Skillfolio.Domain.LearnedSkills;

public class LearnedSkill
{
    // Primary Key
    public int Id { get; private set; }
    public int UserId { get; private set; }
    // Foreign Key
    public int SkillId { get; private set; }
    public int ProficiencyLevel { get; private set;  }

    public LearnedSkill(CreateLearnedSkillCommand command)
    {
        UserId = command.UserId;
        SkillId = command.SkillId;
        ProficiencyLevel = command.ProficiencyLevel;
    }
}