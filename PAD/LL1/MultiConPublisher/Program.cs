using System.Text;
using Newtonsoft.Json;
using MulticonPublisher;
using Common.Data;

Console.WriteLine("[PUBLISHER]");

var publisher = new Publisher();
var connected = publisher.StartConnect(CommonConstants.BROKER_IP, CommonConstants.BROKER_PORT);
if (!connected) return;

int nrOfBytes = 0;
string msgInJson = string.Empty;
Payload payload = new();
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
