namespace MultiConClient;

using System;
using System.Threading.Tasks;

class Program
{
    static Client client;
    static readonly string host = "127.0.0.1";
    static readonly int port = 8;

    static public async Task Main(string[] args)
    {
        client = new Client(host, port);
        await client.ConnectSocketAsync();

        var text = "";
        while (text is not "stop")
        {
            text = Console.ReadLine();
            client.SendMessage(text!);
            
        }
        Console.ReadKey();
    }
}