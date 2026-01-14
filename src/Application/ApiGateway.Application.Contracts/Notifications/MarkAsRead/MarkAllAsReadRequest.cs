namespace ApiGateway.Application.Contracts.Notifications.MarkAsRead;

public class MarkAllAsReadRequest
{
    public required string UserId { get; init; }
}