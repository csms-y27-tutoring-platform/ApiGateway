using ApiGateway.Application.Contracts.Notifications.GetNotification;

namespace ApiGateway.Application.Contracts.Notifications.GetNotifications;

public class GetNotificationsResponseDto
{
    public required NotificationResponse[] Notifications { get; init; }
}