namespace SignalRServer.Hubs;

public interface IMessageHubClient
{
    Task ReceiveMessage(string message);
}
