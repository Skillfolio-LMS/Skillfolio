using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skillfolio.Domain.Skills.Query;

namespace Skillfolio.Api.Controllers;

[ApiController]
[Route("api")]
public class SkillController(IMediator mediator) : ControllerBase
{
    [HttpGet("skills")]
    public async Task<IActionResult> GetSkills(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllSkills(), cancellationToken));
    }
}