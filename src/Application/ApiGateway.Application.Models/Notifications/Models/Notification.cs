using ApiGateway.Application.Models.Notifications.Enums;

namespace ApiGateway.Application.Models.Notifications.Models;

public class Notification
{
    public required string Id { get; init; }

    public required string UserId { get; init; }

    public required string Title { get; init; }

    public required string Content { get; init; }

    public NotificationType Type { get; init; }

    public NotificationStatus Status { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset ReadAt { get; init; }
}