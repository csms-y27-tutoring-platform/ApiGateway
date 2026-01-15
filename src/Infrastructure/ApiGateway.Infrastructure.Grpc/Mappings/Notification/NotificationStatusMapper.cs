namespace ApiGateway.Infrastructure.Grpc.Mappings.Notification;

public static class NotificationStatusMapper
{
    public static Application.Models.Notifications.Enums.NotificationStatus ToApplication(
        this NotificationStatus notificationStatus)
    {
        Application.Models.Notifications.Enums.NotificationStatus status = notificationStatus switch
        {
            NotificationStatus.Read => Application.Models.Notifications.Enums.NotificationStatus.Read,
            NotificationStatus.Unread => Application.Models.Notifications.Enums.NotificationStatus.Unread,
            _ => throw new ArgumentOutOfRangeException(nameof(notificationStatus)),
        };
        return status;
    }
}