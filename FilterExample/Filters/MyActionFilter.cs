using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_Example.Filters
{
    public class MyActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"[ACTION FILTER]: OnActionExecuting...");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"[ACTION FILTER]: OnActionExecuted");
        }
    }


    public class MyAsyncActionFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Logic before the action method executes can be added here
            Console.WriteLine("[ACTION FILTER]: OnActionExecuting...");

            var resultContext = await next();

            // Logic after the action method executes can be added here
            Console.WriteLine("[ACTION FILTER]: OnActionExecuted");
        }
    }
}
