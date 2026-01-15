using ApiGateway.Application.Contracts.GatewayServices;
using ApiGateway.Application.Contracts.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Presentation.Controllers;

[ApiController]
[Route("api/schedule")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleGatewayService _service;

    public ScheduleController(IScheduleGatewayService service)
    {
        _service = service;
    }

    [HttpPost("slots")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateScheduleSlotResponseDto>> CreateSlotAsync(
        [FromBody] CreateScheduleSlotRequestDto request)
    {
        CreateScheduleSlotResponseDto response = await _service.CreateScheduleSlotAsync(request);
        return Ok(response);
    }
}