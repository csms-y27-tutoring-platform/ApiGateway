namespace ApiGateway.Application.Contracts.Notifications.MarkAsRead;

public class MarkAsReadRequestDto
{
    public required Guid NotificationId { get; init; }
}