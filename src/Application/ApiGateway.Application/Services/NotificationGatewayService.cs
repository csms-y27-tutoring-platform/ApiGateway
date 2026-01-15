using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Application.Contracts.GatewayServices;
using ApiGateway.Application.Contracts.Notifications.GetNotification;
using ApiGateway.Application.Contracts.Notifications.GetNotifications;
using ApiGateway.Application.Contracts.Notifications.GetUnreadCount;
using ApiGateway.Application.Contracts.Notifications.MarkAsRead;

namespace ApiGateway.Application.Services;

public class NotificationGatewayService : INotificationGatewayService
{
    private readonly INotificationGrpcClient _client;

    public NotificationGatewayService(INotificationGrpcClient client)
    {
        _client = client;
    }

    public async Task<GetNotificationsResponseDto> GetNotificationsAsync(GetNotificationsRequestDto requestDto)
    {
        if (requestDto.UserId == Guid.Empty)
        {
            throw new ArgumentException("UserId is can't be empty");
        }

        return await _client.GetNotificationsAsync(requestDto);
    }

    public async Task<NotificationResponse> GetNotificationAsync(GetNotificationRequestDto requestDto)
    {
        if (requestDto.NotificationId == Guid.Empty)
        {
            throw new ArgumentException("NotificationId is can't be empty");
        }

        return await _client.GetNotificationAsync(requestDto);
    }

    public async Task<GetUnreadCountResponseDto> GetUnreadCountAsync(GetUnreadCountRequestDto requestDto)
    {
        if (requestDto.UserId == Guid.Empty)
        {
            throw new ArgumentException("UserId is can't be empty");
        }

        return await _client.GetUnreadCountAsync(requestDto);
    }

    public async Task MarkAsReadAsync(MarkAsReadRequestDto requestDto)
    {
        if (requestDto.NotificationId == Guid.Empty)
        {
            throw new ArgumentException("NotificationId is can't be empty");
        }

        await _client.MarkAsReadAsync(requestDto);
    }

    public async Task MarkAllAsReadAsync(MarkAllAsReadRequestDto requestDto)
    {
        if (requestDto.UserId == Guid.Empty)
        {
            throw new ArgumentException("UserId is can't be empty");
        }

        await _client.MarkAllAsReadAsync(requestDto);
    }
}