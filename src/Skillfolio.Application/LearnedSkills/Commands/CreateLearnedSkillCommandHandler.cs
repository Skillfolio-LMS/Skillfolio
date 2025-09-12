using MediatR;
using Skillfolio.Application.Exceptions;
using Skillfolio.Domain.LearnedSkills;
using Skillfolio.Domain.LearnedSkills.Commands;
using Skillfolio.Domain.Skills;
using Skillfolio.Infrastructure.Interfaces;

namespace Skillfolio.Application.LearnedSkills.Commands;

public class CreateLearnedSkillCommandHandler(IRepository<Skill> skillRepo, IRepository<LearnedSkill> learnedSkillRepo) : IRequestHandler<CreateLearnedSkillCommand, CreateLearnedSkillCommandResponse>
{
    public async Task<CreateLearnedSkillCommandResponse> Handle(CreateLearnedSkillCommand request, CancellationToken cancellationToken)
    {
        var isSkillExist = await skillRepo.IsExistAsync(request.SkillId, cancellationToken);

        if (!isSkillExist)
        {
            throw new ObjectNotFoundException($"Skill with id {request.SkillId} not found");
        }
        
        var learnedSkill = await learnedSkillRepo.AddAsync(new LearnedSkill(request), cancellationToken);
        return new CreateLearnedSkillCommandResponse() {Id = learnedSkill.Id};
    }
}