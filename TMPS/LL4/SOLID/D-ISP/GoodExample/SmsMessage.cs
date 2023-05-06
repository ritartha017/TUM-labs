namespace GoodExample;

using GoodExample.Abstract;

class SmsMessage : ITextMessage
{
    public string Text { get; set; } = "";
    public string FromAddress { get; set; } = "";
    public string ToAddress { get; set; } = "";
    public void Send() => Console.WriteLine("Sending via Sms the message: {Text}");
}
