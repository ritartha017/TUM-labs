using System.Net.Sockets;
using Common.Data;

namespace MultiConBroker;

public class Client
{
	public Socket socket;

	public Client(Socket accepted)
	{
		this.socket = accepted;
        this.socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
    }

    void ReceivedCallback(IAsyncResult ar)
    {
		try
		{
            socket.EndReceive(ar);

			var buff = new byte[CommonConstants.RECEIVER_BUFF_SIZE];
			var rec = socket.Receive(buff, buff.Length, 0);

			if (rec < buff.Length)
				Array.Resize<byte>(ref buff, rec);
			if (buff.Length <= 0)
			{
				Close();
				return;
			}

            Received?.Invoke(this, new ReceivedHandler(socket, buff));

			socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			Close();
        }
    }

	public void Close()
	{
        var address = socket.RemoteEndPoint.ToString();
        SubscribersRepository.Remove(address);

        Disconnected?.Invoke(this, new DisconnectedHandler(socket));
		socket.Close();
		socket.Dispose();
    }

    public event EventHandler<ReceivedHandler> Received;
    public event EventHandler<DisconnectedHandler> Disconnected;
}