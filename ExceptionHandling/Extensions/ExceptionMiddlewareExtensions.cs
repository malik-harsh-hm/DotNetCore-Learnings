using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace ExceptionHandling.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError => {
                appError.Run(async context => {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        switch (contextFeature.Error)
                        {
                            case NotFoundException:
                                context.Response.StatusCode = StatusCodes.Status404NotFound;
                                break;
                            case UnauthorizedException:
                                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                break;
                            case ForbiddenException:
                                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                                break;
                            case BadRequestException:
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                break;
                            default:
                                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                break;
                        }

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }


    // Custom Error Model
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    // Custom Exception Classes
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }

    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
