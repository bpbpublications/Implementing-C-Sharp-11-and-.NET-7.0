namespace NewFeatures.AutoDefaults;

public struct StructExample
{
    public int Id { get; set; } // Auto-initialized to 0

    public string Name { get; set; } // Auto-initialized to ""

    public bool Active { get; set; } // Auto-initialized to false
}