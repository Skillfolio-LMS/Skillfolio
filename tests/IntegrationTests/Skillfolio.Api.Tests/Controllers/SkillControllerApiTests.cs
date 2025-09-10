using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Database;

namespace Skillfolio.Api.Tests.Controllers;

public class SkillControllerApiTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public SkillControllerApiTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _factory.ResetDatabase();
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetSkills_ShouldReturnAllSkills()
    {
        // Arrange
        var newSkill = new Skill(skillName: "java", category: "Programming");

        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Skills.Add(newSkill);
            db.SaveChanges();
        }

        // Act
        var response = await _client.GetAsync("api/skills");

        // Assert
        using (new AssertionScope())
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var skills = await response.Content.ReadFromJsonAsync<List<Skill>>();
            skills.Should().NotBeNull();
            skills.Should().ContainSingle();
            skills.First().SkillName.Should().Be(newSkill.SkillName);
            skills.First().Category.Should().Be(newSkill.Category);
        }
    }
}