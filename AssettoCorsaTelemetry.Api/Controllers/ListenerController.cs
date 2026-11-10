using AssettoCorsaTelemetry.Core.Interfaces;
using AssettoCorsaTelemetry.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AssettoCorsaTelemetry.Api.Controllers;

[ApiController]
[Route("listener")]
public class ListenerController(ISessionService sessionService) : ControllerBase
{
    [HttpPost("session")]
    public async Task<IActionResult> AddSession([FromBody] SessionDto dto)
    {
        await sessionService.AddSessionAsync(dto);
        return NoContent();
    }
}