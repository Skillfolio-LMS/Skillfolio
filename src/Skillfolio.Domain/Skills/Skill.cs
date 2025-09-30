using Skillfolio.Domain.LearnedSkills;

namespace Skillfolio.Domain.Skills;

public class Skill
{

    #region MyRegion
    public const int NameMaxLength = 50;
    public const int CategoryMaxLength = 20;
    #endregion
    
    // Primary Key
    public int Id { get; private set; }
    public string SkillName { get; private set; }
    public string Category { get; private set; }
    
    public Skill(string skillName, string category)
    {
        SkillName = skillName;
        Category = category;
    }
}