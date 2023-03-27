namespace HostedBlazorWasmDemo.Client.Models;

public class CounterModel
{
    [MaxIncrementValidator]
    public int IncrementBy { get; set; } = 1;
}
