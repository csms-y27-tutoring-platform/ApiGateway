using Grpc.Core;
using Microsoft.AspNetCore.Http;

namespace ApiGateway.Presentation.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ArgumentException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (RpcException ex)
        {
            context.Response.StatusCode = ex.StatusCode switch
            {
                StatusCode.OK => StatusCodes.Status200OK,
                StatusCode.InvalidArgument => StatusCodes.Status400BadRequest,
                StatusCode.NotFound => StatusCodes.Status404NotFound,
                StatusCode.Unavailable => StatusCodes.Status503ServiceUnavailable,
                StatusCode.PermissionDenied => StatusCodes.Status403Forbidden,
                StatusCode.Unknown => StatusCodes.Status500InternalServerError,
                StatusCode.DeadlineExceeded => StatusCodes.Status504GatewayTimeout,
                StatusCode.AlreadyExists => StatusCodes.Status409Conflict,
                StatusCode.Unauthenticated => StatusCodes.Status401Unauthorized,
                StatusCode.ResourceExhausted => StatusCodes.Status429TooManyRequests,
                StatusCode.FailedPrecondition => StatusCodes.Status412PreconditionFailed,
                StatusCode.Aborted => StatusCodes.Status409Conflict,
                StatusCode.OutOfRange => StatusCodes.Status416RangeNotSatisfiable,
                StatusCode.Unimplemented => StatusCodes.Status501NotImplemented,
                StatusCode.Internal => StatusCodes.Status500InternalServerError,
                StatusCode.DataLoss => StatusCodes.Status500InternalServerError,
                StatusCode.Cancelled => StatusCodes.Status408RequestTimeout,
                _ => StatusCodes.Status500InternalServerError,
            };
        }
    }
}