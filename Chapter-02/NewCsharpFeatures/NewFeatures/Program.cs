using NewFeatures.AutoDefaults;
using NewFeatures.GenericAttributes;
using NewFeatures.PatternMatching;
using NewFeatures.StringOperations;

Console.WriteLine("Testing auto-defaults.");

var testStruct = new StructExample();

Console.WriteLine($"""

Struct data is as follows:

Id: {testStruct.Id},
Name: {testStruct.Name},
Active: {testStruct.Active}

""");

Console.WriteLine("Testing Generic Attributes.");

var methods = typeof(ParametrizedClass).GetMethods();

foreach (var method in methods)
{
    var attribute = method?
        .GetCustomAttributes(false)
        .FirstOrDefault();

    if (attribute != null)
        Console.WriteLine($"""

        Method name: {method?.Name},
        Method attribute: {attribute.GetType()}
        """);
}

Console.WriteLine("");
Console.WriteLine("Testing Pattern Matching.");

var collectionOperations = new CollectionOperations();

Console.WriteLine($"""

MatchExactSequence returns {collectionOperations.MatchExactSequence},
MatchWithDiscard returns {collectionOperations.MatchWithDiscard},
MatchWithRange returns {collectionOperations.MatchWithRange}

""");

var charSpanOperations = new CharSpanOperations();

Console.WriteLine($"""
MatchWholeSpan returns {charSpanOperations.MatchWholeSpan},
MatchWholeReadOnlySpan returns {charSpanOperations.MatchWholeReadOnlySpan},
MatchWholeSpanWithDiscard returns {charSpanOperations.MatchWholeSpanWithDiscard},
MatchWholeReadOnlySpanWithDiscard returns {charSpanOperations.MatchWholeReadOnlySpanWithDiscard},
MatchWholeSpanByRange returns {charSpanOperations.MatchWholeSpanByRange},
MatchWholeReadOnlySpanBtRange returns {charSpanOperations.MatchWholeReadOnlySpanBtRange}

""");

Console.WriteLine("Testing String Operations.");

var interpolatedStrings = new InterpolatedStrings();

Console.WriteLine($"""

Old style interpolation:

{interpolatedStrings.OldStyleInterpolation}

New style interpolation:

{interpolatedStrings.NewStyleInterpolation}

""");

var stringLiterals = new StringLiterals();

Console.WriteLine($"""

Raw string literal:

{stringLiterals.RawStringLiteral}

String literal with interpolation:

{stringLiterals.NewStyleInterpolation}

""");