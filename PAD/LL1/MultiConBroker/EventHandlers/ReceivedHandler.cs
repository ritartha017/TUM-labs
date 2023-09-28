using System.Text;

namespace MultiConBroker;

public class ReceivedHandler : EventArgs
{
    public Publisher Publisher { get; private set; }
    public byte[] data { get; private set; }

    public ReceivedHandler(Publisher p, byte[] data)
    {
        Publisher = p;
        this.data = (byte[])data.Clone();
        // Handle(data);
    }

    /*
    private void Handle(byte[] data)
    {
        var payloadString = Encoding.UTF8.GetString(data);

        if (payloadString.StartsWith("subscribe#"))
        {
            var topic = payloadString.Split("subscribe#").LastOrDefault();
            SubscribersRepository.Add(new Subscriber() { Topic = topic, Address = Publisher.EndPoint.Address.ToString() });
            
        }
        else if (IsValidJson(payloadString))
        {
            Payload? payload = JsonConvert.DeserializeObject<Payload>(payloadString);
            PayloadQueue.Add(payload);
        }
    }

    private static bool IsValidJson(string strInput)
    {
        if (string.IsNullOrWhiteSpace(strInput)) { return false; }
        strInput = strInput.Trim();
        if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
            (strInput.StartsWith("[") && strInput.EndsWith("]")))
        {
            try
            {
                var obj = JToken.Parse(strInput);
                return true;
            }
            catch (JsonReaderException jex)
            {
                Console.WriteLine(jex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        else
        {
            return false;
        }
    }*/
}