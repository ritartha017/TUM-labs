using System.Text;
using MultiConBroker.Repos;
using Newtonsoft.Json;

namespace MultiConBroker;

public class MessagesSender
{
    private const int TTSleep = 500;

    public void SendMessages()
    {
        while (true)
        {
            while (!PayloadQueue.IsEmpty)
            {
                var paylaod = PayloadQueue.GetNext();

                if (paylaod != null)
                {
                    var subscribers = SubscribersRepository.GetSubscribersByTopic(paylaod.Topic);

                    foreach (var subcriber in subscribers)
                    {
                        var payloadString = JsonConvert.SerializeObject(paylaod);
                        Console.WriteLine(payloadString);
                        byte[] data = Encoding.UTF8.GetBytes(payloadString);

                        subcriber.Socket.Send(data);
                    }
                }
            }
            Thread.Sleep(TTSleep);
        }
    }

    public MessagesSender()
    {
    }
}
