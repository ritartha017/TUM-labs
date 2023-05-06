namespace GoodExample.Abstract;

interface IVoiceMessage : IMessage
{
    byte[] Voice { get; set; }
}
