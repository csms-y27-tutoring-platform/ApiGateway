using ApiGateway.Presentation.Middleware;
using System.Text.Json.Serialization;

namespace ApiGateway.Presentation.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        serviceCollection.AddScoped<ExceptionMiddleware>();

        return serviceCollection;
    }
}