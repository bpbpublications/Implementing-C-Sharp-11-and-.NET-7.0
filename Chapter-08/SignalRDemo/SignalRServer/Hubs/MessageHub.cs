using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace SignalRServer.Hubs;

public class MessageHub : Hub
{
    public async Task BroadcastMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task SendToOthers(string message)
    {
        await Clients.Others.SendAsync("ReceiveMessage", message);
    }

    public async Task SendToSelf(string message)
    {
        await Clients.Caller.SendAsync("ReceiveMessage", message);
    }

    public async Task SendToSpecificClient(string message, string clientId)
    {
        await Clients.Client(clientId).SendAsync("ReceiveMessage", message);
    }

    public async Task SendToGroup(string message, string groupName)
    {
        await Clients.Group(groupName).SendAsync("ReceiveMessage", message);
    }

    public async Task SendToOthersInGroup(string message, string groupName)
    {
        await Clients.OthersInGroup(groupName).SendAsync("ReceiveMessage", message);
    }

    public async Task BroadcastStream(IAsyncEnumerable<string> stream)
    {
        await foreach (var item in stream)
        {
            await Clients.Caller.SendAsync($"Server received {item}");
        }
    }

    public async IAsyncEnumerable<string> TriggerStream(
        int jobsToProcess,
        [EnumeratorCancellation]
            CancellationToken cancellationToken)
    {
        for (var i = 0; i < jobsToProcess; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return $"Job {i} processed successfully.";
            await Task.Delay(1000, cancellationToken);
        }
    }

    public override async Task OnConnectedAsync()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "ConnectedClients");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "ConnectedClients");
        await base.OnDisconnectedAsync(exception);
    }
}