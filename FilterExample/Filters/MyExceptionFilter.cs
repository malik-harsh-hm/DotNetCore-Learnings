using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_Example.Filters
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            switch (context.Exception)
            {
                case NotFoundException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case UnauthorizedException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;
                case ForbiddenException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    break;
                case BadRequestException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            context.Result = new JsonResult(new ErrorDetails
            {
                StatusCode = context.HttpContext.Response.StatusCode,
                Message = context.Exception.Message
            });
        }
    }
    // Custom Error Model

    internal class ErrorDetails
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
