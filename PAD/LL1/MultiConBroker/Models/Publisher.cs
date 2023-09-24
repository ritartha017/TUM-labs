using System.Net;
using System.Net.Sockets;

namespace MultiConBroker;

public class Publisher
{
	public string ID { get; private set; }
	public IPEndPoint? EndPoint { get; private set; }
	private Socket publisherSocket;

	public Publisher(Socket accepted)
	{
		publisherSocket = accepted;
		ID = Guid.NewGuid().ToString();
		EndPoint = (IPEndPoint?)publisherSocket.RemoteEndPoint;
        publisherSocket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
	}

    void ReceivedCallback(IAsyncResult ar)
    {
		try
		{
            publisherSocket.EndReceive(ar, out SocketError response);

            if (response == SocketError.Success)
			{
				var buff = new byte[8192];
				var rec = publisherSocket.Receive(buff, buff.Length, 0);

				if (rec < buff.Length)
					Array.Resize<byte>(ref buff, rec);
                if (buff.Length == 0) return;

                Received?.Invoke(this, new PublisherReceivedHandler(this, buff));

				publisherSocket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Close();
            Disconnected?.Invoke(this, new PublisherDisconnectedHandler(this));
        }
    }

	public void Close()
	{
		publisherSocket.Close();
		publisherSocket.Dispose();
	}

    public event EventHandler<PublisherReceivedHandler> Received;
    public event EventHandler<PublisherDisconnectedHandler> Disconnected;
}