namespace UDPClient;

class Program
{
    private static async Task Main()
    {
        var chat = new UDPClient("127.0.0.1", 99);

        _ = Task.Run(chat.ReceiveMessageAsync);

        bool continueLoop = true;

        while (continueLoop)
        {
            try
            {
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
                    //await chat.SendMessageToIpAsync(endUserRemoteIP!);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
