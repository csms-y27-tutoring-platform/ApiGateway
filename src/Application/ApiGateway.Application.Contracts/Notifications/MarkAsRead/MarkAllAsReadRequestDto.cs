namespace ApiGateway.Application.Contracts.Notifications.MarkAsRead;

public class MarkAllAsReadRequestDto
{
    public required Guid UserId { get; init; }
}