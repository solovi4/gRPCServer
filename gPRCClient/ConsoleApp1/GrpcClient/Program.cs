using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = 
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            
            using var channel = GrpcChannel.ForAddress("https://localhost:5001", 
                new GrpcChannelOptions { HttpHandler = httpHandler});
            
            var client = new Randomizer.RandomizerClient(channel);

            Console.WriteLine("Enter для следующего числа");

            do
            {
                var reply = await client.GetRandomAsync(new RandomRequest());
                Console.WriteLine("Ответ сервера: " + reply.Numb);
            } while (Console.ReadKey().Key == System.ConsoleKey.Enter);

        }
    }
}