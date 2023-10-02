namespace Common.Data;

public class Payload
{
    public string Topic { get; set; }
    public string Message { get; set; }

    public Payload(string topic, string message)
    {
        this.Topic = topic;
        this.Message = message;
    }

    public Payload()
    {
    }
}