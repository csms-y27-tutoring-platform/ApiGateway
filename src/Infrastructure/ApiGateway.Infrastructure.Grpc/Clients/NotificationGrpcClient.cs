using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Application.Contracts.Notifications.GetNotification;
using ApiGateway.Application.Contracts.Notifications.GetNotifications;
using ApiGateway.Application.Contracts.Notifications.GetUnreadCount;
using ApiGateway.Application.Contracts.Notifications.MarkAsRead;
using ApiGateway.Infrastructure.Grpc.Mappings.Notification;

namespace ApiGateway.Infrastructure.Grpc.Clients;

public class NotificationGrpcClient : INotificationGrpcClient
{
    private readonly NotificationService.NotificationServiceClient _client;

    public NotificationGrpcClient(NotificationService.NotificationServiceClient client)
    {
        _client = client;
    }

    public async Task<GetNotificationsResponseDto> GetNotificationsAsync(GetNotificationsRequestDto requestDto)
    {
        var request = new GetNotificationsRequest { UserId = requestDto.UserId };

        GetNotificationsResponse response = await _client.GetNotificationsAsync(request);

        var dto = new GetNotificationsResponseDto
        {
            Notifications = response.Notifications.Select(n => n.ToApplication()).ToArray(),
        };
        return dto;
    }

    public async Task<NotificationResponse> GetNotificationAsync(GetNotificationRequestDto requestDto)
    {
        var request = new GetNotificationRequest { NotificationId = requestDto.NotificationId.ToString() };

        Notification response = await _client.GetNotificationAsync(request);

        NotificationResponse dto = response.ToApplication();
        return dto;
    }

    public async Task<GetUnreadCountResponseDto> GetUnreadCountAsync(GetUnreadCountRequestDto requestDto)
    {
        var request = new GetUnreadCountRequest { UserId = requestDto.UserId };

        GetUnreadCountResponse response = await _client.GetUnreadCountAsync(request);

        var dto = new GetUnreadCountResponseDto { Count = response.Count };
        return dto;
    }

    public async Task MarkAsReadAsync(MarkAsReadRequestDto requestDto)
    {
        var request = new MarkAsReadRequest { NotificationId = requestDto.NotificationId };

        await _client.MarkAsReadAsync(request);
    }

    public async Task MarkAllAsReadAsync(MarkAllAsReadRequestDto requestDto)
    {
        var request = new MarkAllAsReadRequest { UserId = requestDto.UserId };

        await _client.MarkAllAsReadAsync(request);
    }
}