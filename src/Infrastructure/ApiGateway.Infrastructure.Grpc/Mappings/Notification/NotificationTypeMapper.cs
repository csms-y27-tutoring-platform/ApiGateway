namespace ApiGateway.Infrastructure.Grpc.Mappings.Notification;

public static class NotificationTypeMapper
{
    public static Application.Models.Notifications.Enums.NotificationType ToApplication(
        this NotificationType notificationType)
    {
        Application.Models.Notifications.Enums.NotificationType type = notificationType switch
        {
            NotificationType.BookingCreated => Application.Models.Notifications.Enums.NotificationType.Created,
            NotificationType.BookingCancelled => Application.Models.Notifications.Enums.NotificationType.Cancelled,
            NotificationType.Reminder => Application.Models.Notifications.Enums.NotificationType.Reminder,
            _ => throw new ArgumentOutOfRangeException(nameof(notificationType)),
        };
        return type;
    }
}