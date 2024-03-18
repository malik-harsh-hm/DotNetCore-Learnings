using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterExample.Filters
{
    public class MyResourceFilter : Attribute, IResourceFilter, IResultFilter, IAuthorizationFilter, IExceptionFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"[RESOURCE FILTER]: OnResourceExecuting...");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"[RESOURCE FILTER]: OnResourceExecuted");
        }
    }
}
