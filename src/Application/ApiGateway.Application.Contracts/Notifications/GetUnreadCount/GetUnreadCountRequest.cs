namespace ApiGateway.Application.Contracts.Notifications.GetUnreadCount;

public class GetUnreadCountRequest
{
    public required string UserId { get; init; }
}