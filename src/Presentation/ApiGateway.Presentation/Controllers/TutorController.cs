using ApiGateway.Application.Contracts.GatewayServices;
using ApiGateway.Application.Contracts.Tutors.CreateTutor;
using ApiGateway.Application.Contracts.Tutors.DeactivateTutor;
using ApiGateway.Application.Contracts.Tutors.GetTutor;
using ApiGateway.Application.Contracts.Tutors.UpdateTutor;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Presentation.Controllers;

[ApiController]
[Route("api/tutors")]
public class TutorController : ControllerBase
{
    private readonly ITutorGatewayService _service;

    public TutorController(ITutorGatewayService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateTutorResponseDto>> CreateTutorAsync(
        [FromBody] CreateTutorRequestDto createTutorRequestDto)
    {
        CreateTutorResponseDto response = await _service.CreateTutorAsync(createTutorRequestDto);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UpdateTutorResponseDto>> UpdateTutorAsync(
        [FromRoute] Guid id,
        [FromBody] UpdateTutorRequestDto body)
    {
        var request = new UpdateTutorRequestDto
        {
            TutorId = id,
            FirstName = body.FirstName,
            LastName = body.LastName,
            Phone = body.Phone,
            Description = body.Description,
            PreferredFormat = body.PreferredFormat,
            AverageLessonDurationMinutes = body.AverageLessonDurationMinutes,
            TeachingSubjects = body.TeachingSubjects,
        };
        UpdateTutorResponseDto response = await _service.UpdateTutorAsync(request);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetTutorResponseDto>> GetTutorAsync(
        [FromRoute] Guid id)
    {
        var request = new GetTutorRequestDto { TutorId = id };
        GetTutorResponseDto response = await _service.GetTutorAsync(request);
        return Ok(response);
    }

    [HttpPost("{id:guid}/deactivate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeactivateTutorResponseDto>> DeactivateTutorAsync(
        [FromRoute] Guid id)
    {
        var request = new DeactivateTutorRequestDto { TutorId = id };
        DeactivateTutorResponseDto response = await _service.DeactivateTutor(request);
        return Ok(response);
    }
}