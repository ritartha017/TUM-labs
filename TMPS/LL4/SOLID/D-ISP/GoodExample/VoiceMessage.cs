using GoodExample.Abstract;

namespace GoodExample;

class VoiceMessage : IVoiceMessage
{
    public string ToAddress { get; set; } = "";
    public string FromAddress { get; set; } = "";

    public byte[] Voice { get; set; } = Array.Empty<byte>();
    public void Send() => Console.WriteLine("Sending via voice mail.");
}
