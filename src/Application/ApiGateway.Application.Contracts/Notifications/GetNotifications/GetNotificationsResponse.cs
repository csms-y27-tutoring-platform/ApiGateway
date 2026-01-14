using ApiGateway.Application.Models.Notifications.Models;

namespace ApiGateway.Application.Contracts.Notifications.GetNotifications;

public class GetNotificationsResponse
{
    public required Notification[] Notifications { get; init; }
}