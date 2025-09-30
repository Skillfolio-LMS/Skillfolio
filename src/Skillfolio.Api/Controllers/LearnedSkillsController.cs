using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skillfolio.Domain.LearnedSkills.Commands;

namespace Skillfolio.Api.Controllers;

[ApiController]
[Route("skills/learned-skill")]
public class LearnedSkillsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> LearnedSkill([FromBody] CreateLearnedSkillCommand command, CancellationToken cancellationToken)
    {
        return Created(nameof(LearnedSkill), await mediator.Send(command, cancellationToken));
    }
}