using System.Diagnostics;

namespace ObservabilityImprovements;

public static class ActivityMonitoring
{
    public static void MonitorStoppedActivity()
    {
        var activity = new Activity("test");
        activity.Start();
        activity.Stop();

        Console.WriteLine($"Is activity stopped? {activity.IsStopped}");
    }

    public static void DemoCurrentChangedEvent()
    {
        Activity.CurrentChanged += ChangeEvent;

        var activity = new Activity("test");
        activity.Start();
        activity = new Activity("test2");
        activity.Start();

        void ChangeEvent(object? sender, ActivityChangedEventArgs e)
        {
            Console.WriteLine($"Operation changed from {
                (e.Previous?.OperationName ?? "[No Activity]")} to {
                    e.Current?.OperationName}.");
        }
    }

    public static void DemoActivityEnumerators()
    {
        var activity = new Activity("test");

        activity.SetTag("tag1", "value1");
        activity.SetTag("tag2", "value2");
        activity.SetTag("tag3", "value2");

        Console.WriteLine("Activity has the following tags:");

        foreach (ref readonly KeyValuePair<string, object?> tag 
            in activity.EnumerateTagObjects())
        {
            Console.WriteLine($"Tag name: {tag.Key}, tag value: {tag.Value}");
        }

        activity.AddEvent(new ActivityEvent("event1"));
        activity.AddEvent(new ActivityEvent("event2"));

        Console.WriteLine("Activity has the following events:");

        foreach (var ev in activity.EnumerateEvents())
        {
            Console.WriteLine($"Event name: {ev.Name}");
        }
    }

    public static void DemoInnerTagEnumerators()
    {
        var tagCollection = new List<KeyValuePair<string, object?>>()
        {
            new KeyValuePair<string, object?>("tag1", "value1"),
            new KeyValuePair<string, object?>("tag2", "value2"),
        };

        var activityLink = new ActivityLink(default, new ActivityTagsCollection(tagCollection));

        Console.WriteLine("ActivityLink has the following tags:");

        foreach (ref readonly KeyValuePair<string, object?> tag 
            in activityLink.EnumerateTagObjects())
        {
            Console.WriteLine($"Tag name: {tag.Key}, tag value: {tag.Value}");
        }            

        var e = new ActivityEvent("TestEvent", tags: new ActivityTagsCollection(tagCollection));

        Console.WriteLine("ActivityEvent has the following tags:");

        foreach (ref readonly KeyValuePair<string, object?> tag 
            in e.EnumerateTagObjects())
        {
            Console.WriteLine($"Tag name: {tag.Key}, tag value: {tag.Value}");
        } 
    }
}