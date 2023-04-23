﻿using TeacherExample;

//string multicastIP = "239.5.6.7";
string multicastIP = "224.0.0.0";
int multicastPort = 5001;

UdpChat chat = new UdpChat(multicastIP, multicastPort);

Console.WriteLine("Input format: <IP>:<TEXT>");
Console.WriteLine("IP = 0 -> Multicast");

chat.StartReceiveLoop();

while (true)
{
    try
    {
        string input = Console.ReadLine() ?? "";
        var splitted = input.Split(":");
        string toIP = splitted[0];
        string text = splitted[1];

        if (toIP == "0")
        {
            chat.SendToGeneral(text);
        }
        else
        {
            chat.SendTo(toIP, text);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message.ToString());
    }
}