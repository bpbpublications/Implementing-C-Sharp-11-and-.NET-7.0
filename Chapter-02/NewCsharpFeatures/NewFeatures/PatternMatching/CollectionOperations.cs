namespace NewFeatures.PatternMatching;

public class CollectionOperations
{
    private List<int> items = new List<int>
    {
        2, 3, 6, 7, 8
    };

    public bool MatchExactSequence => items is [2, 3, 6, 7, 8];

    public bool MatchWithDiscard => items is [2, _, 6, _, 8];

    public bool MatchWithRange => items is [2, ..];
}