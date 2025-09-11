using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skillfolio.Domain.LearnedSkills.Commands;
using Skillfolio.Domain.Skills.Query;

namespace Skillfolio.Api.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSkills(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllSkills(), cancellationToken));
    }
    
    [HttpPost("Learned-skill")]
    public async Task<IActionResult> LearnedSkill([FromBody] CreateLearnedSkillCommand command, CancellationToken cancellationToken)
     {
         return Created(nameof(LearnedSkill), await mediator.Send(command, cancellationToken));
     }
    
}