var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

// Custom Middleware
app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"), builder => 
{ 
    builder.Use(async (context, next) => 
    { 
        Console.WriteLine("Branch: Before logic"); 
        await next.Invoke(); 
        Console.WriteLine("Branch: After logic"); 
    }); 
    builder.Run(async context => 
    { 
        Console.WriteLine($"Branch: Terminal middleware"); 
        await context.Response.WriteAsync("Hello from the Map branch"); 
    }); 
});
app.Use(async (context, next) =>
{
    Console.WriteLine($"Before logic");
    await next.Invoke();
    Console.WriteLine($"After logic");
});
app.Run(async context =>
{
    Console.WriteLine($"Terminal middleware");
    await context.Response.WriteAsync("Hello from the Run delegate");
});

app.MapControllers();

app.Run();
