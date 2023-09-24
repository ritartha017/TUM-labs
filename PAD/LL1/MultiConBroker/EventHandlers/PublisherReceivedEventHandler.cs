using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiConBroker;

public class PublisherReceivedHandler : EventArgs
{
    public Publisher Publisher { get; private set; }
    public byte[] data { get; private set; }

    public PublisherReceivedHandler(Publisher p, byte[] d)
    {
        Publisher = p;
        data = (byte[])d.Clone();
        Handle(data);
    }

    private void Handle(byte[] data)
    {
        var payloadString = Encoding.UTF8.GetString(data);

        if (payloadString.StartsWith("subscribe#"))
        {
            
        }
        else if (IsValidJson(payloadString))
        {
            Payload? payload = JsonConvert.DeserializeObject<Payload>(payloadString);
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
    }
}