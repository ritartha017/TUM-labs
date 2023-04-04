using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_GUI;

public partial class ServerForm : Form
{
    Socket socket;
    Socket accept;

    static Socket Socket()
    {
        return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public ServerForm()
    {
        InitializeComponent();
        socket = Socket();
        FormClosing += new FormClosingEventHandler(ServerForm_FormClosing);
    }

    private void ServerForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        socket.Shutdown(SocketShutdown.Both);
        socket.Close();
    }

    private void ListenBtn_Click(object sender, EventArgs e)
    {
        socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3));
        socket.Listen(0);

        new Thread(delegate()
        {
            accept = socket.Accept();
            MessageBox.Show("CONNECTION ACCEPTED!");
            socket.Close();
            Read();
        }).Start();
    }

    private void Read()
    {
        while (true)
        {
            try
            {
                byte[] sizeBuf = new byte[4]; 
                accept.Receive(sizeBuf, 0, sizeBuf.Length, 0);
                int size = BitConverter.ToInt32(sizeBuf, 0);
                MemoryStream ms = new MemoryStream(size);
                while (size > 0)
                {
                    byte[] buffer;
                    if (size < accept.ReceiveBufferSize)
                        buffer = new byte[size];
                    else
                        buffer = new byte[accept.ReceiveBufferSize];
                    int received = accept.Receive(buffer, 0, buffer.Length, 0);
                    size -= received;
                    ms.Write(buffer, 0, buffer.Length);
                }
                ms.Close();
                byte[] data = ms.ToArray();
                ms.Dispose();
                Invoke((MethodInvoker)delegate
                {
                    richTextBox.Text = Encoding.Default.GetString(data);
                });
            }
            catch
            {
                MessageBox.Show("DISCONNECTED FROM SERVER!");
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                break;
            }
        }
        Application.Exit();
    }

    private void SendBtn_Click(object sender, EventArgs e)
    {
        byte[] data = Encoding.Default.GetBytes(sendTextBox.Text);
        accept.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
        accept.Send(data);
    }

    private void ServerForm_Load(object sender, EventArgs e)
    {

    }

    private void richTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}