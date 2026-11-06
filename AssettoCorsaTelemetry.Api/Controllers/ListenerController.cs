using System.Numerics;
using AssettoCorsaTelemetry.Dtos;
using AssettoCorsaTelemetry.Core.Entities;
using AssettoCorsaTelemetry.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssettoCorsaTelemetry.Api.Controllers;

[ApiController]
[Route("listener")]
public class ListenerController(IPhysicsDataService physicsDataService) : ControllerBase
{
    [HttpPost("addphysicsdata")]
    public async Task<IActionResult> AddPhysicsData([FromBody] UnassignedPhysicsDataDto dto)
    {
        try
        {
            UnassignedPhysicsData data = UnassignedPhysicsData.FromDto(dto);
            await physicsDataService.AddPhysicsDataAsync(data);
            return Ok();
        }
        catch (BadHttpRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}