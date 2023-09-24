using System.Text;
using Newtonsoft.Json;
using Publisher;

Console.WriteLine("[PUBLISHER]");

var publisher = new PublisherSocket();
var connected = publisher.StartConnect("127.0.0.1", 8);

if (!connected) return;

int nrOfBytes = 0;
string msgInJson = string.Empty;
Payload payload = new Payload();
while (true)
{
    Console.Write("Enter topic: ");
    payload.Topic = Console.ReadLine()!;
    Console.Write("Enter message: ");
    payload.Message = Console.ReadLine()!;
    msgInJson = JsonConvert.SerializeObject(payload);
    publisher.Send(Encoding.UTF8.GetBytes(msgInJson));
}

publisher.CloseSocket();

Console.ReadLine();
