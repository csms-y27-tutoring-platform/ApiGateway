using ApiGateway.Presentation.Middleware;

namespace ApiGateway.Presentation.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddScoped<ExceptionMiddleware>();

        return serviceCollection;
    }
}