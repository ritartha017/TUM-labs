using GoodExample.Interface;

namespace GoodExample.Abstract;

interface IEmailMessage : ITextMessage
{
    string Subject { get; set; }
}
