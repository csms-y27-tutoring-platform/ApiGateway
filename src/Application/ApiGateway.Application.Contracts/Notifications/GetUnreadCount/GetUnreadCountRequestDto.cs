namespace ApiGateway.Application.Contracts.Notifications.GetUnreadCount;

public class GetUnreadCountRequestDto
{
    public required string UserId { get; init; }
}