using ApiGateway.Application.Models.Notifications.Enums;

namespace ApiGateway.Application.Models.Notifications.Models;

public class Notification
{
    public required Guid Id { get; init; }

    public required Guid UserId { get; init; }

    public required string Title { get; init; }

    public required string Content { get; init; }

    public NotificationType Type { get; init; }

    public NotificationStatus Status { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset ReadAt { get; init; }
}