namespace Skillfolio.Domain.Skills;

public class Skill
{
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