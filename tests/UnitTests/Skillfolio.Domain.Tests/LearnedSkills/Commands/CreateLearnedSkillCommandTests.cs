using FluentAssertions;
using Skillfolio.Domain.LearnedSkills.Commands;

namespace Skillfolio.Domain.Tests.LearnedSkills.Commands;

public class CreateLearnedSkillCommandTests
{
    private readonly CreateLearnedSkillCommandValidator _validator = new();
    private readonly CreateLearnedSkillCommand _command = new()
    {
        UserId = 1,
        SkillId = 1,
        ProficiencyLevel = 3
    };

    [Fact]
    public void Command_WhenValid_ShouldPass()
    {
        // Act
        var result = _validator.Validate(_command);

        // Assert
        result.IsValid.Should().BeTrue();   
    }

    [Fact]
    public void UserId_WhenZero_ShouldFail()
    {
        // Arrange
        _command.UserId = 0;
        
        // Act
        var result = _validator.Validate(_command);
        
        // Assert
        result.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public void SkillId_WhenZero_ShouldFail()
    {
        // Arrange
        _command.SkillId = 0;
        
        // Act
        var result = _validator.Validate(_command);
        
        // Assert
        result.IsValid.Should().BeFalse();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    public void ProficiencyLevel_WhenNotInRangeOneToFive_ShouldFail(int proficiencyLevel)
    {
        // Arrange
        _command.ProficiencyLevel = proficiencyLevel;
        
        // Act
        var result = _validator.Validate(_command);
        
        // Assert
        result.IsValid.Should().BeFalse();
    }
}