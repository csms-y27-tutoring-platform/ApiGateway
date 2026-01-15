using ApiGateway.Application.Contracts.Notifications.GetNotification;
using ApiGateway.Application.Contracts.Notifications.GetNotifications;
using ApiGateway.Application.Contracts.Notifications.GetUnreadCount;
using ApiGateway.Application.Contracts.Notifications.MarkAsRead;

namespace ApiGateway.Application.Abstractions.Clients;

public interface INotificationGrpcClient
{
    Task<GetNotificationsResponseDto> GetNotificationsAsync(GetNotificationsRequestDto requestDto);

    Task<NotificationResponse> GetNotificationAsync(GetNotificationRequestDto requestDto);

    Task<GetUnreadCountResponseDto> GetUnreadCountAsync(GetUnreadCountRequestDto requestDto);

    Task MarkAsReadAsync(MarkAsReadRequestDto requestDto);

    Task MarkAllAsReadAsync(MarkAllAsReadRequestDto requestDto);
}