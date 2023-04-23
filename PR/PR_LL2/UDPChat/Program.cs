namespace UDPChat;

class Program
{
    private static async Task Main(string[] args)
    {
        var chat = new UDPChat("127.0.0.1", 8888);
        //var chat = new UDPChat("239.5.6.7", 5002);

        _ = Task.Run(chat.ReceiveMessageAsync);

        bool continueLoop = true;

        while (continueLoop)
        {
            try {
                string input = Console.ReadLine() ?? "";
                var splitted = input.Split(":");
                string endUserRemoteIP = splitted[0];
                string text = splitted[1];
                
                if (endUserRemoteIP == "0")
                {
                    await chat.SendMessageToGeneralAsync(text);
                }
                else
                {
                    await chat.SendMessageToIpAsync(endUserRemoteIP!);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
