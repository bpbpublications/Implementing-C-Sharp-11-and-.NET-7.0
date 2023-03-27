namespace NewFeatures.PatternMatching;

public class CharSpanOperations
{
    private char[] charArray = new char[3]
    {
        'a',
        'b',
        'c'
    };

    public bool MatchWholeSpan => GetSpan() is ['a', 'b', 'c'];

    public bool MatchWholeReadOnlySpan => GetReadonlySpan() is ['a', 'b', 'c'];

    public bool MatchWholeSpanWithDiscard => GetSpan() is ['a', _, 'c'];

    public bool MatchWholeReadOnlySpanWithDiscard => GetReadonlySpan() is ['a', _, 'c'];

    public bool MatchWholeSpanByRange => GetSpan() is ['a', ..];

    public bool MatchWholeReadOnlySpanBtRange => GetReadonlySpan() is ['a', ..];

    private Span<char> GetSpan()
    {
        Span<char> span = charArray;
        return span;
    }

    private ReadOnlySpan<char> GetReadonlySpan()
    {
        ReadOnlySpan<char> span = charArray;
        return span;
    }
}