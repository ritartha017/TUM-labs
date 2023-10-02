using System.Net;
using System.Net.Sockets;

namespace MultiConBroker;

public class Publisher
{
	public IPEndPoint? EndPoint;
	public Socket publisherSocket;

	public Publisher(Socket accepted)
	{
		publisherSocket = accepted;
		EndPoint = (IPEndPoint?)publisherSocket.RemoteEndPoint;
	}

	public void StartReceive()
	{
		publisherSocket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
	}

    void ReceivedCallback(IAsyncResult ar)
    {
		try
		{
            publisherSocket.EndReceive(ar);

			var buff = new byte[8192];
			var rec = publisherSocket.Receive(buff, buff.Length, 0);

			if (rec < buff.Length)
				Array.Resize<byte>(ref buff, rec);
			if (buff.Length <= 0)
			{
				Close();
				return;
			}

            Received?.Invoke(this, new ReceivedHandler(this, buff));

			publisherSocket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			Close();
        }
    }

	public void Close()
	{
		publisherSocket.Close();
		publisherSocket.Dispose();
		Disconnected?.Invoke(this, new DisconnectedHandler(this));
	}

    public event EventHandler<ReceivedHandler> Received;
    public event EventHandler<DisconnectedHandler> Disconnected;
}