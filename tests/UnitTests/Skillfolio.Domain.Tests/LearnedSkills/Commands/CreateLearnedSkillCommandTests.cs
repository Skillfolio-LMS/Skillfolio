using FluentAssertions;
using Skillfolio.Domain.LearnedSkills.Commands;

namespace Skillfolio.Domain.Tests.LearnedSkills.Commands;

public class CreateLearedSkillCommandTests
{
    private readonly CreateLearnedSkillCommandValidator _validator;
    private CreateLearedSkillCommand _command;

    public CreateLearedSkillCommandTests()
    {
        _validator = new CreateLearnedSkillCommandValidator();
        _command = new CreateLearedSkillCommand
        {
            UserId = 1,
            SkillId = 1,
            ProficiencyLevel = 3
        };
    }
    
    [Fact]
    public void Validate_WhenCommandIsValid_ShouldPassValidation()
    {
        // Act
        var result = _validator.Validate(_command);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_WhenSkillIdIsInvalid_ShouldFailValidation()
    {
        // Arrange
        _command.UserId = 0;
        
        // Act
        var result = _validator.Validate(_command);
        
        // Assert
        result.IsValid.Should().BeFalse();
    }
    
    [Fact]
    public void Validate_WhenUserIdIsInvalid_ShouldFailValidation()
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
    public void Validate_WhenProficiencyLevelIsInvalid_ShouldFailValidation(int proficiencyLevel)
    {
        // Arrange
        _command.ProficiencyLevel = proficiencyLevel;
        
        // Act
        var result = _validator.Validate(_command);
        
        // Assert
        result.IsValid.Should().BeFalse();
    }
}