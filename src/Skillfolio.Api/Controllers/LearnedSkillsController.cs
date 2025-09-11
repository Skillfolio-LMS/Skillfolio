using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Skillfolio.Domain.LearnedSkills.Commands;

namespace Skillfolio.Api.Controllers;

[ApiController]
[Route("api/skills")]
public class LearnedSkillsController(IMediator mediator) : ControllerBase
{
    [HttpPost("learned-skill")]
    public async Task<IActionResult> LearnedSkill([FromBody] CreateLearnedSkillCommand command, CancellationToken cancellationToken)
    {
        return Created(nameof(LearnedSkill), await mediator.Send(command, cancellationToken));
    }
}