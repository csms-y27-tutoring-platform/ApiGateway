using ApiGateway.Application.Contracts.GatewayServices;
using ApiGateway.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiGateway.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddGatewayServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IBookingGatewayService, BookingGatewayService>();
        serviceCollection.AddScoped<INotificationGatewayService, NotificationGatewayService>();
        serviceCollection.AddScoped<IScheduleGatewayService, ScheduleGatewayService>();
        serviceCollection.AddScoped<ITutorGatewayService, TutorGatewayService>();
        return serviceCollection;
    }
}