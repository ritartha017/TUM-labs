namespace MultipleConServUI;

using System.Net.Sockets;

public partial class Server : Form
{
    Listener listener;
    public Server()
    {
        InitializeComponent();
        listener = new Listener("127.0.0.1", 8);
        listener.SocketAccepted += new Listener.SocketAcceptedHandler(Listener_SocketAccepted);
        listener.Start();
    }

    private static void Listener_SocketAccepted(Socket socket)
    {
        Console.WriteLine("New Connection: {0}\n{1}\n===========", socket.RemoteEndPoint, DateTime.Now);
        Client client = new(socket);
        client.Received += new Client.ClientReceivedHandler(ClientReceived);
        client.Disconnected += new Client.ClientDisconnectedHandler(ClientDisconnected);

        Invoke((MethodInvoker)delegate
        {
            ListViewItem listViewI = new();
            listViewI.Text = client.EndPoint.ToString();
            listViewI.SubItems.Add(client.Id);
            listViewI.SubItems.Add("XX");
            listViewI.SubItems.Add("XX");
            listClients.Items.Add(listViewI);
            TimeReceivedColumnHeader.Text = "fdsfsf";
        });
    }

    private static void ClientDisconnected(Client sender)
    {
    }

    private static void ClientReceived(Client sender, byte[] data)
    {
    }

    private void listClients_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
