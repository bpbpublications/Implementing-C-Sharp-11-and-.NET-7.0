using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OpenApi;
using WebApiAppWithMinimalApis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddW3CLogging(logging =>
{
    logging.AdditionalRequestHeaders.Add("custom-header");
    logging.AdditionalRequestHeaders.Add("xanother-custom-header");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRequestDecompression();

app.UseCookiePolicy(new CookiePolicyOptions
{
    ConsentCookieValue = "yes"
});

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithDescription("The endpoint for retrieving weather forecatsts.")
.WithOpenApi(operation => {
    operation.Summary = "The endpoint for retrieving weather forecatsts.";
    return operation;
});

app.MapGet("/repeated-strings", (string[] names) => $"value 1: {names[0]}, value 2: {names[1]}, value 3: {names[2]}");

app.MapGet("/parameters-object", ([AsParameters] ParamsRequest request) => $"Id{request.Id}, Page: {request.Page}");

app.MapTypedDataApi();

app.MapGet("/cached-date", () => DateTime.UtcNow.ToString()).CacheOutput();

app.MapPost("/upload", async (IFormFile file) =>
{
    using var stream = File.OpenWrite("test.txt");
    await file.CopyToAsync(stream);
}).RequireAuthorization();


string GetGreetingMessage(string name) => $"User {name} is allowed to access reource";

app.MapGet("/filter/invocation-context/{name}", GetGreetingMessage)
    .AddEndpointFilter(async (routeHandlerInvocationContext, next) =>
    {
        var name = (string)routeHandlerInvocationContext.Arguments[0];
        if (name == "Chris Davidson")
        {
            return Results.Problem("Access is not allowed for Chris Davidson!");
        }
        return await next(routeHandlerInvocationContext);
    });


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal struct ParamsRequest
{
    public int Id { get; set; }
    public int Page { get; set; }
}