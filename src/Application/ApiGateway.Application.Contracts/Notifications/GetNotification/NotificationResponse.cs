using ApiGateway.Application.Models.Notifications.Enums;

namespace ApiGateway.Application.Contracts.Notifications.GetNotification;

public class NotificationResponse
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