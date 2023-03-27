namespace NewFeatures.StringOperations;

public class StringLiterals
{

    public string RawStringLiteral => """
    This text may contain any symbols, including
    newlines, "quoted text", 
        indentations, and so on.

    There is no need to escape any characters.
    """;

    public string NewStyleInterpolation => $"""
    This is a combination of a new string 
        literal and interpolated string.

    This is a value from inserted code: {5 + 8}.
        
    """;
}