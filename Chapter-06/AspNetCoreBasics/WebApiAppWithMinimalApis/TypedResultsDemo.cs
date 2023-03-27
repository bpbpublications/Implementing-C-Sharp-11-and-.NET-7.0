using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApiAppWithMinimalApis;

public class Data
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "test";
}

public static class TypedResultsDemo
{
    public static void MapTypedDataApi(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/typed-data", ReturnTypedResult);
        routes.MapGet("/typed-data/{id}", (int id) => ReturnSingeItem(id));
    }

    public static Task<IResult> ReturnTypedResult()
    {
        return Task.FromResult(Results.Ok(Task.FromResult(new Data())));
    }

    public static Results<Ok<Data>, NotFound> ReturnSingeItem(int id)
    {
        return id == 1
                ? TypedResults.Ok(new Data())
                : TypedResults.NotFound();
    }
}
