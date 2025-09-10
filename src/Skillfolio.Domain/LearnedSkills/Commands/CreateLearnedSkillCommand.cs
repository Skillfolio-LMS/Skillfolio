using MediatR;

namespace Skillfolio.Domain.LearnedSkills.Commands;

public class CreateLearnedSkillCommand : IRequest<CreateLearnedSkillCommandResponse>
{
    public int UserId { get; set; }
    public int SkillId { get; set; }
    public int ProficiencyLevel { get; set; }
}