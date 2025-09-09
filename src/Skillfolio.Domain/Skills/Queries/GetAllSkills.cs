using MediatR;

namespace Skillfolio.Domain.Skills.Query;

public class GetAllSkills : IRequest<List<Skill>>
{
}