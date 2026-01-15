using ApiGateway.Application.Contracts.Notifications.GetNotification;

namespace ApiGateway.Infrastructure.Grpc.Mappings.Notification;

public static class NotificationMapper
{
    public static NotificationResponse ToApplication(
        this Grpc.Notification notification)
    {
        var dto = new NotificationResponse
        {
            Id = notification.Id,
            UserId = notification.UserId,
            Title = notification.Title,
            Content = notification.Content,
            Type = notification.Type.ToApplication(),
            Status = notification.Status.ToApplication(),
            CreatedAt = notification.CreatedAt.ToDateTimeOffset(),
            ReadAt = notification.ReadAt.ToDateTimeOffset(),
        };
        return dto;
    }
}