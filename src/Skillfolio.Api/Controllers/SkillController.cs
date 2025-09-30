using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skillfolio.Domain.Skills.Query;

namespace Skillfolio.Api.Controllers;

[ApiController]
[Route("skills")]
public class SkillController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSkills(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetAllSkills(), cancellationToken));
    }
}