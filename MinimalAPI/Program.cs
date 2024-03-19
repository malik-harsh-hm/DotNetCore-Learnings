
using Microsoft.AspNetCore.Http.HttpResults;

namespace MinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapGet("/api/resource", () => {
                // Implement logic to get all resources
                return Results.Ok($"All Resources");
            });

            app.MapGet("/api/resource/{id}", (int id) =>
            {
                // Implement logic to get resource by ID
                return Results.Ok($"Resource with ID {id}");
            });

            app.MapPost("/api/resource", (HttpRequest request) =>
            {
                // Implement logic to create a new resource
                return Results.Created("/api/resource/1", $"Resource created successfully");
            });

            app.MapPut("/api/resource/{id}", (int id, HttpRequest request) =>
            {
                // Implement logic to update resource by ID
                return Results.Ok($"Resource with ID {id} updated successfully");
            });

            app.MapDelete("/api/resource/{id}", (int id) =>
            {
                // Implement logic to delete resource by ID
                return Results.Ok($"Resource with ID {id} deleted successfully");
            });

            app.Run();
        }
    }
}
