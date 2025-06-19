
using Grpc.Net.Client;
using GrpcService1;

// Con este creo una conexion hacia el puerto del gRPC
using (var channel = GrpcChannel.ForAddress("https://localhost:7027"))
{
    var client = new Beers.BeersClient(channel);
    var reply = await client.GetBeersAsync(new BeersRequest { }).ResponseAsync;
    foreach (var item in reply.Beers)
    {
        Console.WriteLine(item);
    }
}