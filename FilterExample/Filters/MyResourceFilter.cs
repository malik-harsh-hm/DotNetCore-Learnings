using Microsoft.AspNetCore.Mvc.Filters;

namespace Filter_Example.Filters
{
    public class MyResourceFilter : Attribute, IResourceFilter
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
