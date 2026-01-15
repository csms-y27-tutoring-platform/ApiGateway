namespace ApiGateway.Application.Contracts.Notifications.GetUnreadCount;

public class GetUnreadCountRequestDto
{
    public required Guid UserId { get; init; }
}