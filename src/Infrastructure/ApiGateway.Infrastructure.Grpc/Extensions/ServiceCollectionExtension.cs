using ApiGateway.Application.Abstractions.Clients;
using ApiGateway.Infrastructure.Grpc.Clients;
using ApiGateway.Infrastructure.Grpc.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ApiGateway.Infrastructure.Grpc.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOptions<BookingOption>().BindConfiguration("GrpcClients:BookingService");
        serviceCollection.AddGrpcClient<BookingService.BookingServiceClient>((sp, o) =>
        {
            IOptions<BookingOption> option = sp.GetRequiredService<IOptions<BookingOption>>();
            o.Address = new Uri(option.Value.Address);
        });

        serviceCollection.AddOptions<TutorOption>().BindConfiguration("GrpcClients:TutorService");
        serviceCollection.AddGrpcClient<TutorService.TutorServiceClient>((sp, o) =>
        {
            IOptions<TutorOption> option = sp.GetRequiredService<IOptions<TutorOption>>();
            o.Address = new Uri(option.Value.Address);
        });
        serviceCollection.AddGrpcClient<ScheduleService.ScheduleServiceClient>((sp, o) =>
        {
            IOptions<TutorOption> option = sp.GetRequiredService<IOptions<TutorOption>>();
            o.Address = new Uri(option.Value.Address);
        });

        serviceCollection.AddOptions<NotificationOption>().BindConfiguration("GrpcClients:NotificationService");
        serviceCollection.AddGrpcClient<NotificationService.NotificationServiceClient>((sp, o) =>
        {
            IOptions<NotificationOption> option = sp.GetRequiredService<IOptions<NotificationOption>>();
            o.Address = new Uri(option.Value.Address);
        });

        serviceCollection.AddScoped<IBookingGrpcClient, BookingGrpcClient>();
        serviceCollection.AddScoped<ITutorGrpcClient, TutorGrpcClient>();
        serviceCollection.AddScoped<INotificationGrpcClient, NotificationGrpcClient>();
        serviceCollection.AddScoped<IScheduleGrpcClient, ScheduleGrpcClient>();

        return serviceCollection;
    }
}