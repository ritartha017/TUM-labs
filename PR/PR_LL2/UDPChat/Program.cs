﻿using System.Net.Sockets;

using UDPChatNamespace;

<<<<<<< HEAD
var chat = new UDPChat("224.1.1.1", 5002);
//var chat = new UDPChat("239.5.6.7", 5002);
=======
//var chat = new UDPChat("225.1.1.1", 5002);
var chat = new UDPChat("239.5.6.7", 5002);
>>>>>>> a1ca6159cef4976c9ca5482823579928cfef1200
//var chat = new UDPChat("192.168.0.103", 5021);

_ = Task.Run(chat.ReceiveMessageAsync);

bool continueLoop = true;

while (continueLoop)
{
    try
    {
        string input = Console.ReadLine() ?? "";
        if (!input.StartsWith(">"))
        {
            await chat.SendMessageToGeneralAsync(input);
        }
        else
        {
            var splitted = input.Split(":");
            string endUserRemoteIP = splitted[0][1..]; // trim ">" symbol
            string text = splitted[1];
            await chat.SendMessageToIpAsync(endUserRemoteIP, text);
        }
    }
    catch (SocketException se)
    {
        Console.Error.WriteLine("Socket Exception: "
                                + se.ToString());
    }
    catch (Exception e)
    {
        Console.Error.WriteLine("Exception: "
                                + e.ToString());
    }
}