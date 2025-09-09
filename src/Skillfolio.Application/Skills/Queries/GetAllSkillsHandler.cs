using MediatR;
using Skillfolio.Domain.Skills;
using Skillfolio.Domain.Skills.Query;
using Skillfolio.Infrastructure.Interfaces;

namespace Skillfolio.Application.Skills.Queries;

public class GetAllSkillsHandler(IRepository<Skill> skillRepo) : IRequestHandler<GetAllSkills, List<Skill>>
{
    public async Task<List<Skill>> Handle(GetAllSkills request, CancellationToken cancellationToken)
    {
        var skills = await skillRepo.GetAllAsync(cancellationToken);
        return skills;
    }
}