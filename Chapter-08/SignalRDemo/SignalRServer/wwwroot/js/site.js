const connection = new signalR.HubConnectionBuilder()
    .withUrl("/messageHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.on("ReceiveMessage", (message) => {
    $('#signalr-message-panel').prepend($('<div />').text(message));
});

$('#btn-broadcast').click(function () {
    var message = $('#broadcast').val();
    connection.invoke("BroadcastMessage", message).catch(err => console.error(err.toString()));
});

$('#btn-others').click(function () {
    var message = $('#others').val();
    connection.invoke("SendToOthers", message).catch(err => console.error(err.toString()));
});

$('#btn-self').click(function () {
    var message = $('#self').val();
    connection.invoke("SendToSelf", message).catch(err => console.error(err.toString()));
});

$('#btn-individual').click(function () {
    var message = $('#individual').val();
    var connectionId = $('#connection-id').val();
    connection.invoke("SendToSpecificClient", message, connectionId).catch(err => console.error(err.toString()));
});

$('#btn-group').click(function () {
    var message = $('#group').val();
    var group = $('#group1').val();
    connection.invoke("SendToGroup", message, group).catch(err => console.error(err.toString()));
});


$('#btn-others-in-group').click(function () {
    var message = $('#others-in-group').val();
    var group = $('#group2').val();
    connection.invoke("SendToOthersInGroup", message, group).catch(err => console.error(err.toString()));
});

$('#btn-broadcast-stream').click(function () {
    var message = $('#broadcast-stream').val();
    var messages = message.split(';');
    var subject = new signalR.Subject();

    connection.send("BroadcastStream", subject).catch(err => console.error(err.toString()));
    for (var i = 0; i < messages.length; i++) {
        subject.next(messages[i]);
    }

    subject.complete();
});

$('#btn-trigger-stream').click(function () {
    var numberOfJobs = parseInt($('#number-of-jobs').val(), 10);

    connection.stream("TriggerStream", numberOfJobs)
        .subscribe({
            next: (message) => $('#signalr-message-panel').prepend($('<div />').text(message))
        });
});

async function start() {
    try {
        await connection.start();
        console.log('connected');
    } catch (err) {
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(async () => {
    await start();
});

start();