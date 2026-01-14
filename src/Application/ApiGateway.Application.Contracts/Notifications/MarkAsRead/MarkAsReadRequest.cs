namespace ApiGateway.Application.Contracts.Notifications.MarkAsRead;

public class MarkAsReadRequest
{
    public required string NotificationId { get; init; }
}