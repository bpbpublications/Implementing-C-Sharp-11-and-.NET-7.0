using Google.Protobuf;
using Grpc.Core;
using GrpcServiceApp;
using System.Text;

namespace GrpcServiceApp.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(GenerateReplyMessage(request));
        }

        public override async Task RequestManyReplies(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            var i = 3;

            while (i > 0)
            {
                await responseStream.WriteAsync(GenerateReplyMessage(request));
                i--;
            }
        }

        public override async Task<HelloReply> SendManyRequests(IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
        {
            var reply = new HelloReply();

            await foreach (var request in requestStream.ReadAllAsync())
            {
                reply = GenerateReplyMessage(request);
            }

            return reply;
        }

        public override async Task InitiateBidirectionalStreaming(IAsyncStreamReader<HelloRequest> requestStream, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            await foreach(var request in requestStream.ReadAllAsync())
            {
                await responseStream.WriteAsync(GenerateReplyMessage(request));
            }
        }

        private HelloReply GenerateReplyMessage(HelloRequest request)
        {
            var message = "Hello " + request.Name;

            return new HelloReply
            {
                Message = message,
                MessageId = 1,
                ContentInBytes = ByteString.CopyFrom(Encoding.ASCII.GetBytes(message)),
                MessageSizeInKilobytes = (float)ByteString.CopyFrom(Encoding.ASCII.GetBytes(message)).Length / 1024,
                ReplyProcessed = false
            };
        }
    }
}