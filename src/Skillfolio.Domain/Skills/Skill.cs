namespace Skillfolio.Domain.Skills;

public class Skill(string skillName, string category)
{

    #region MyRegion
    public const int NameMaxLength = 50;
    public const int CategoryMaxLength = 20;
    #endregion
    
    // Primary Key
    public int Id { get; private set; }
    public string SkillName { get; private set; } = skillName;
    public string Category { get; private set; } = category;
}