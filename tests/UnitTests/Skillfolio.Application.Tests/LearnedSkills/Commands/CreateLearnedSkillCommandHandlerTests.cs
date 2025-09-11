using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Moq.AutoMock;
using Skillfolio.Application.Exceptions;
using Skillfolio.Application.LearnedSkills.Commands;
using Skillfolio.Domain.LearnedSkills;
using Skillfolio.Domain.LearnedSkills.Commands;
using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Interfaces;

namespace Skillfolio.Application.Tests.LearnedSkills.Commands;

public class CreateLearnedSkillCommandHandlerTests
{
    private readonly AutoMocker _mocker;
    private readonly CreateLearnedSkillCommandHandler _handler;

    public CreateLearnedSkillCommandHandlerTests()
    {
        _mocker = new AutoMocker();
        _handler = _mocker.CreateInstance<CreateLearnedSkillCommandHandler>();
    }

    [Fact]
    public async Task WhenSkillExists_ShouldAddLearnedSkill()
    {
        // Arrange
        var command = new CreateLearnedSkillCommand { UserId = 1, SkillId = 10, ProficiencyLevel = 3 };

        // Mock skill repository
        var skillRepoMock = _mocker.GetMock<IRepository<Skill>>();
        skillRepoMock.Setup(x => x.IsExistAsync(command.SkillId, It.IsAny<CancellationToken>())).ReturnsAsync(true);

        // Mock learnedSkill repository
        var learnedSkillRepoMock = _mocker.GetMock<IRepository<LearnedSkill>>();
        learnedSkillRepoMock.Setup(x => x.AddAsync(It.IsAny<LearnedSkill>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new LearnedSkill(command));

        // Act
        var response = await _handler.Handle(command, CancellationToken.None);

        // Assert
        using (new AssertionScope())
        {
            response.Should().NotBeNull();
            learnedSkillRepoMock.Verify(x => x.AddAsync(It.Is<LearnedSkill>(ls => ls.UserId == command.UserId && ls.SkillId == command.SkillId && ls.ProficiencyLevel == command.ProficiencyLevel), It.IsAny<CancellationToken>()), Times.Once);
        }
    }

    [Fact]
    public async Task Handle_ShouldThrowObjectNotFoundException_WhenSkillDoesNotExist()
    {
        // Arrange
        var command = new CreateLearnedSkillCommand { UserId = 1, SkillId = 99, ProficiencyLevel = 2 };

        var skillRepoMock = _mocker.GetMock<IRepository<Skill>>();
        skillRepoMock.Setup(x => x.IsExistAsync(command.SkillId, It.IsAny<CancellationToken>())).ReturnsAsync(false);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        using (new AssertionScope())
        {
            var exception = await Assert.ThrowsAsync<ObjectNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
            exception.StatusCode.Should().Be(404);
        }
    }
}