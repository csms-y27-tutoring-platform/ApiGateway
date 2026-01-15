using ApiGateway.Application.Contracts.GatewayServices;
using ApiGateway.Application.Contracts.Notifications.GetNotification;
using ApiGateway.Application.Contracts.Notifications.GetNotifications;
using ApiGateway.Application.Contracts.Notifications.GetUnreadCount;
using ApiGateway.Application.Contracts.Notifications.MarkAsRead;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Presentation.Controllers;

[ApiController]
[Route("api/notifications")]
public class NotificationController : ControllerBase
{
    private readonly INotificationGatewayService _service;

    public NotificationController(INotificationGatewayService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetNotificationsResponseDto>> GetNotificationsAsync(
        [FromQuery] Guid userId)
    {
        var request = new GetNotificationsRequestDto { UserId = userId };
        GetNotificationsResponseDto response = await _service.GetNotificationsAsync(request);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<NotificationResponse>> GetNotificationAsync(Guid id)
    {
        var request = new GetNotificationRequestDto { NotificationId = id };
        NotificationResponse response = await _service.GetNotificationAsync(request);
        return Ok(response);
    }

    [HttpGet("unread-count")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetUnreadCountResponseDto>> GetUnreadCountAsync(
        [FromQuery] Guid userId)
    {
        var request = new GetUnreadCountRequestDto { UserId = userId };
        GetUnreadCountResponseDto response = await _service.GetUnreadCountAsync(request);
        return Ok(response);
    }

    [HttpPost("{id:guid}/read")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> MarkAsReadAsync(Guid id)
    {
        var request = new MarkAsReadRequestDto { NotificationId = id };
        await _service.MarkAsReadAsync(request);
        return Ok();
    }

    [HttpPost("read-all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> MarkAllAsReadAsync([FromQuery] Guid userId)
    {
        var request = new MarkAllAsReadRequestDto { UserId = userId };
        await _service.MarkAllAsReadAsync(request);
        return Ok();
    }
}