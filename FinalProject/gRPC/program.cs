using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Greet; // Ensure the namespace matches the generated code

namespace ClientgPRC2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Set up the channel to communicate with the gRPC server
            using var channel = GrpcChannel.ForAddress("http://localhost:50051");
            var client = new Greeter.GreeterClient(channel);

            // Create a new request and send it to the server
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "World" });

            // Output the server's response
            Console.WriteLine("Greeter 클라이언트가 받은 응답: " + reply.Message);
        }
    }
}
