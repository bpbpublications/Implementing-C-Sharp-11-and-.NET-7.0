namespace CoreLibraryImprovements;

public static class NewStreamFeatures
{
    public static void DemoReadExactly()
    {
       using var fileStream = File.Open("output.json", FileMode.Open);

        var buffer = new byte[10];
        fileStream.ReadExactly(buffer);

        Console.WriteLine($"""
        Bytes read with ReadExactly:
        {BitConverter.ToString(buffer)}
        """);
    }

    public static void DemoReadAtLeast()
    {
       using var fileStream = File.Open("output.json", FileMode.Open);

        var buffer = new byte[10];
        fileStream.ReadAtLeast(buffer, 10);

        Console.WriteLine($"""
        Bytes read with ReadAtLeast:
        {BitConverter.ToString(buffer)}
        """);
    }
}