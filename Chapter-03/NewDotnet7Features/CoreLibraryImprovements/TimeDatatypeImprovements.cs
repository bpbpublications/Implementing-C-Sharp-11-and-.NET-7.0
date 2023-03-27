namespace CoreLibraryImprovements;

public class TimeDatatypeImprovements
{
    public static void DemoNewTimeFeatures()
    {
        var dateTime = new DateTime(2022, 3, 2, 15, 00, 30, 30, 30);

        Console.WriteLine($"""
            DateTime object is {dateTime} with {dateTime.Microsecond
            } microseconds and {dateTime.Nanosecond} nanoseconds.

            """);

        var dateTimeOffset = new DateTimeOffset(2022, 
            3, 2, 15, 00, 30, 30, 30, 
            TimeSpan.FromMicroseconds(60 * 1000 * 1000));

        Console.WriteLine($"""
            DateTimeOffset object is {dateTime} with {dateTime.Microsecond
            } microseconds and {dateTime.Nanosecond} nanoseconds.

            """);

        var timeOnly = new TimeOnly(15, 00, 30, 30, 30);

        Console.WriteLine($"""
            TimeOnly object is {timeOnly} with {timeOnly.Microsecond
            } microseconds and {timeOnly.Nanosecond} nanoseconds.

            """);

        var timeSpan = new TimeSpan(19, 3, 40, 20, 30, 30);

        Console.WriteLine($"""
            TimeSpan object is {timeSpan} with {timeSpan.Microseconds
            } microseconds and {timeSpan.Nanoseconds} nanoseconds.
            Ticks per microsecond: {TimeSpan.TicksPerMicrosecond}.
            Nanoseconds per tick: {TimeSpan.NanosecondsPerTick}.
            
            """);
    }
}