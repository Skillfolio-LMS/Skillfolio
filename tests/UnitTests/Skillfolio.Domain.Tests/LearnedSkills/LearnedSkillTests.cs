using FluentAssertions;
using FluentAssertions.Execution;
using Skillfolio.Domain.LearnedSkills;
using Skillfolio.Domain.LearnedSkills.Commands;

namespace Skillfolio.Domain.Tests.LearnedSkills;

public class LearnedSkillTests
{
    [Fact]
    public void CreateLearnedSkill_ShouldInitializeProperties()
    {
        // Arrange
        var command = new CreateLearedSkillCommand
        {
            UserId = 1,
            SkillId = 2,
            ProficiencyLevel = 3
        };

        // Act
        var learnedSkill = new LearnedSkill(command);

        // Assert
        using (new AssertionScope())
        {
            learnedSkill.UserId.Should().Be(command.UserId);
            learnedSkill.SkillId.Should().Be(command.SkillId);
            learnedSkill.ProficiencyLevel.Should().Be(command.ProficiencyLevel);
        }
    }
}