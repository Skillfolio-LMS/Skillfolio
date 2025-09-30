

using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using Skillfolio.Domain.LearnedSkills.Commands;
using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Database;

namespace Skillfolio.Api.Tests.Controllers;

public class LearnedSkillsControllerApiTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public LearnedSkillsControllerApiTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _factory.ResetDatabase();
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task WhenSkillExists_ShouldAddLearnedSkillAndSaveInDb()
    {
        // Arrange
        var skill = new Skill(skillName: "C#", category: "Programming");
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Skills.Add(skill);
            db.SaveChanges();
        }

        var command = new CreateLearnedSkillCommand
        {
            UserId = 1,
            SkillId = skill.Id,
            ProficiencyLevel = 3
        };

        // Act
        var response = await _client.PostAsJsonAsync("/skills/learned-skill", command);

        // Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var responseObj = await response.Content.ReadFromJsonAsync<CreateLearnedSkillCommandResponse>();
            responseObj.Should().NotBeNull();
            responseObj!.Id.Should().BeGreaterThan(0);
            
            using var scope = _factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var learnedSkillInDb = db.LearnedSkills.FirstOrDefault(ls => ls.Id == responseObj.Id);
            learnedSkillInDb.Should().NotBeNull();
            learnedSkillInDb!.UserId.Should().Be(command.UserId);
            learnedSkillInDb.SkillId.Should().Be(command.SkillId);
            learnedSkillInDb.ProficiencyLevel.Should().Be(command.ProficiencyLevel);
        }
    }

    [Fact]
    public async Task PostLearnedSkill_ShouldReturnNotFound_WhenSkillDoesNotExist()
    {
        var command = new CreateLearnedSkillCommand
        {
            UserId = 1,
            SkillId = 999,
            ProficiencyLevel = 2
        };

        // Act
        var response = await _client.PostAsJsonAsync("/skills/learned-skill", command);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
