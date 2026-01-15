namespace ApiGateway.Application.Contracts.Notifications.GetNotifications;

public class GetNotificationsRequestDto
{
    public required Guid UserId { get; set; }
}