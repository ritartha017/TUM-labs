namespace MultiConServer;

using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static Listener? listener;
    static List<Client>? clients;

    static void Main()
    {
        listener = new Listener("127.0.0.1", 8);
        listener.SocketAccepted += new Listener.SocketAcceptedHandler(Listener_SocketAccepted);
        listener.StartListening();
        clients = new List<Client>();

        var text = "";
        while (text is not "stop")
        {
            text = Console.ReadLine();
            SendMessageToClients(clients, text);
        }
        Console.ReadKey();
    }

    private static void SendMessageToClients(List<Client> clients, string? message)
    {
        for (int i = 0; i < clients.Count; i++)
            clients[i].SendMessage(message!);
    }

    private static void Listener_SocketAccepted(Socket acceptedSocket)
    {
        Client? client = new(acceptedSocket);
        client.Received += new Client.ClientReceivedHandler(ClientReceived);
        client.Disconnected += new Client.ClientDisconnectedHandler(ClientDisconnected);
        Console.WriteLine($"Connection accepted -> {client.Id}");
        clients!.Add(client);
    }

    private static void ClientDisconnected(Client sender)
    {
        for (int i = 0; i < clients!.Count; i++)
        {
            if (clients[i].Id == sender.Id)
            {
                clients.RemoveAt(i);
                break;
            }
        }
    }

    private static void ClientReceived(Client sender, byte[] data)
    {
        for (int i = 0; i < clients!.Count; i++)
        {
            if (clients[i].Id == sender.Id)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"Client({clients[i].Id}): ");
                Console.ResetColor();
                Console.WriteLine(Encoding.Default.GetString(data));
                break;
            }
        }
    }
}
