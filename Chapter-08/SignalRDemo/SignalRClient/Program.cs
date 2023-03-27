using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Channels;

var url = args[0];

var hubConnection = new HubConnectionBuilder()
                         .WithUrl(url)
                         .Build();

hubConnection.On<string>("ReceiveMessage",
    message => Console.WriteLine($"Message received from the server: {message}"));

await hubConnection.StartAsync();

var running = true;

while (running)
{
    var message = string.Empty;
    var groupName = string.Empty;

    Console.WriteLine("Please specify the action:");
    Console.WriteLine("0 - Broadcast a message to all");
    Console.WriteLine("1 - Send a message to others");
    Console.WriteLine("2 - Send a message to self");
    Console.WriteLine("3 - Send a message to a specific client");
    Console.WriteLine("4 - Send a to a group");
    Console.WriteLine("5 - Send a message to others in the group");
    Console.WriteLine("6 - Broadcast messages from client");
    Console.WriteLine("7 - Trigger a stream from the server");
    Console.WriteLine("exit - Terminate the program");

    var action = Console.ReadLine();

    if (action != "7")
    {
        Console.WriteLine("Please specify the message:");
        message = Console.ReadLine();
    }

    if (action == "4")
    {
        Console.WriteLine("Please specify the group name:");
        groupName = Console.ReadLine();
    }

    switch (action)
    {
        case "0":
            await hubConnection.SendAsync("BroadcastMessage", message);
            break;
        case "1":
            await hubConnection.SendAsync("SendToOthers", message);
            break;
        case "2":
            await hubConnection.SendAsync("SendToCaller", message);
            break;
        case "3":
            Console.WriteLine("Please specify the connection id:");
            var connectionId = Console.ReadLine();
            await hubConnection.SendAsync("SendToSpecificClient", message, connectionId);
            break;
        case "4":
            await hubConnection.SendAsync("SendToGroup", message, groupName);
            break;
        case "5":
            await hubConnection.SendAsync("SendToOthersInGroup", message, groupName);
            break;
        case "6":
            var channel = Channel.CreateBounded<string>(10);
            await hubConnection.SendAsync("BroadcastStream", channel.Reader);

            foreach (var item in message.Split(';'))
            {
                await channel.Writer.WriteAsync(item);
            }

            channel.Writer.Complete();
            break;
        case "7":
            Console.WriteLine("How many jobs to run?");
            var numberOfJobs = int.Parse(Console.ReadLine() ?? "0");
            var cancellationTokenSource = new CancellationTokenSource();
            var stream = hubConnection.StreamAsync<string>(
                "TriggerStream", numberOfJobs, cancellationTokenSource.Token);

            await foreach (var reply in stream)
            {
                Console.WriteLine(reply);
            }
            break;
        case "exit":
            running = false;
            break;
        default:
            Console.WriteLine("Unknown action. Please try again.");
            break;
    }
}