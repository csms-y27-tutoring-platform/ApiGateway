using ApiGateway.Application.Extensions;
using ApiGateway.Infrastructure.Grpc.Extensions;
using ApiGateway.Presentation.Extensions;
using ApiGateway.Presentation.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddGatewayServices();
builder.Services.AddGrpcClients();

builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();