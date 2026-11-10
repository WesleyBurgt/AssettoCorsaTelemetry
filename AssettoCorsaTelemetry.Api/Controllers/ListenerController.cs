using AssettoCorsaTelemetry.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssettoCorsaTelemetry.Api.Controllers;

[ApiController]
[Route("listener")]
public class ListenerController(IPhysicsDataService physicsDataService) : ControllerBase
{

}