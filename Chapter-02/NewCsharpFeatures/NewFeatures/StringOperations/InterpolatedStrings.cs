namespace NewFeatures.StringOperations;

public class InterpolatedStrings
{
    private List<(string, int)> names = new List<(string, int)>
    {
        ("John", 25),
        ("Mike", 34),
        ("Laurence", 42)
    };

    public string OldStyleInterpolation => $"The age of Laurence is: {names.Where(n => n.Item1 == "Laurence").Select(n => n.Item2).FirstOrDefault()}.";

    public string NewStyleInterpolation => $"The age of Laurence is: {
        names
            .Where(n => n.Item1 == "Laurence")
            .Select(n => n.Item2)
            .FirstOrDefault()
        }.";
}