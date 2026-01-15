namespace ApiGateway.Application.Contracts.Notifications.MarkAsRead;

public class MarkAsReadRequestDto
{
    public required string NotificationId { get; init; }
}