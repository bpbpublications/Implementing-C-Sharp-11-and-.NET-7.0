using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoreLibraryImprovements;

public static class NewJsonFeatures
{
    public static void DemoJsonWriterOptions()
    {
        var options = new JsonWriterOptions
        {
            Indented = true,
            MaxDepth = 5
        };

        using var fileStream = File.Create("output.json");
        using var writer = new Utf8JsonWriter(fileStream, options: options);
        using JsonDocument document = JsonDocument.Parse("""
        {
            "level1": {
                "level2": {
                    "level3": {
                        "key": "value"
                    }
                }
            }
        }
        """);

        var root = document.RootElement;

        if (root.ValueKind == JsonValueKind.Object)
        {
            writer.WriteStartObject();
        }
        else
        {
            return;
        }

        foreach (JsonProperty property in root.EnumerateObject())
        {
            property.WriteTo(writer);
        }

        writer.WriteEndObject();
        writer.Flush();
    }

    public static void ShowDefaultJsonSerializerOptions()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        Console.WriteLine("Showing default JsonSerializerOptions.");
        Console.WriteLine(JsonSerializer.Serialize(JsonSerializerOptions.Default, options));
    }

    public static async Task DemoPatchAsJsonAsync()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        var jsonBody = new { Key = "value" };
        var response = await client.PatchAsJsonAsync("https://localhost", jsonBody);
    }

    public static void DemoJsonPolymorphism()
    {
        Console.WriteLine("Demonstrating basic JSON polymorphism:");
        Console.WriteLine(JsonSerializer.Serialize(new BasicDerivedObject()));

        Console.WriteLine("Demonstrating JSON polymorphism with string type discriminator:");
        var jsonStringDiscrimnator = JsonSerializer.Deserialize<BaseStringDiscriminator>("""
        {
            "$type": "derivedObject",
            "ExtraData":2,
            "BaseData":1
        }
        """);
        Console.WriteLine($"JSON is of derived type: {jsonStringDiscrimnator is DerivedStringDiscriminator}.");


        Console.WriteLine("Demonstrating JSON polymorphism with integer type discriminator:");
        var jsonIntDiscrimnator = JsonSerializer.Deserialize<BaseIntDiscriminator>("""
        {
            "$type": 1,
            "ExtraData":2,
            "BaseData":1
        }
        """);
        Console.WriteLine($"JSON is of derived type: {jsonIntDiscrimnator is DerivedIntDiscriminator}.");
    }
}

[JsonDerivedType(typeof(BasicBaseObject))]
[JsonDerivedType(typeof(BasicDerivedObject))]
public class BasicBaseObject
{
    public int BaseData { get; set; } = 1;
}

public class BasicDerivedObject : BasicBaseObject
{
    public int ExtraData { get; set; } = 2;
}

[JsonDerivedType(typeof(BaseStringDiscriminator), typeDiscriminator: "baseObject")]
[JsonDerivedType(typeof(DerivedStringDiscriminator), typeDiscriminator: "derivedObject")]
public class BaseStringDiscriminator
{
    public int BaseData { get; set; } = 1;
}

public class DerivedStringDiscriminator : BaseStringDiscriminator
{
    public int ExtraData { get; set; } = 2;
}

[JsonDerivedType(typeof(BaseIntDiscriminator), 0)]
[JsonDerivedType(typeof(DerivedIntDiscriminator), 1)]
public class BaseIntDiscriminator
{
    public int BaseData { get; set; } = 1;
}

public class DerivedIntDiscriminator : BaseIntDiscriminator
{
    public int ExtraData { get; set; } = 2;
}