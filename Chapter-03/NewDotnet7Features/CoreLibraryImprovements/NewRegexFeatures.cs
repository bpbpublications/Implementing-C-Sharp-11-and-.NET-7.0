using System.Text.RegularExpressions;

namespace CoreLibraryImprovements;

public partial class NewRegexFeatures
{
    [RegexGenerator(@"^[a-z]+$", RegexOptions.IgnoreCase)]
    public static partial Regex LettersRegex(); 

    public static void DemoPrecompiledRegex(string input)
    {
        Console.WriteLine($"'{input}' matches '^[a-z]+$' RegEx: {LettersRegex().IsMatch(input)}.");
        Console.WriteLine($"The number of matches: {LettersRegex().Count(input)}.");

        var matchEnumerator = LettersRegex().EnumerateMatches(input);

        while (matchEnumerator.MoveNext())
            Console.WriteLine($"Match of {matchEnumerator.Current.Length
            } found at intex {matchEnumerator.Current.Index}.");
    }
}
