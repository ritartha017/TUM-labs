namespace Client_GUI;

using System.Net;
using System.Net.Sockets;
using System.Text;

public partial class ClientForm : Form
{
    readonly Socket socket;
    static Socket Socket()
    {
        return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public ClientForm()
    {
        InitializeComponent();
        socket = Socket();
        FormClosing += new FormClosingEventHandler(ClientForm_FormClosing);
    }

    private void ClientForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        socket.Close();
    }

    private void ConnectBtn_Click(object sender, EventArgs e)
    {
        try
        {
            socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3));
            new Thread(() =>
            {
                Read();
            }).Start();
        }
        catch
        {
            MessageBox.Show("CONNECTION FAILED!");
        }
    }

    private void SendTextBtn_Click(object sender, EventArgs e)
    {
        byte[] data = Encoding.Default.GetBytes(inputTextBox.Text);
        // using a bitconverter to convert the integer of the length to bytes and then we're sending it to server
        // the lenght of a byte array is 4 
        socket.Send(BitConverter.GetBytes(data.Length), 0, 4, 0);
        // after we sended the size, we send the buffer
        socket.Send(data);
    }

    private void Read()
    {
        while (true)
        {
            try
            {
                byte[] sizeBuf = new byte[4]; // hold the length of the data that we're sending
                // so, when we code the client we're going to send the sife of our buffer first before we send
                // the actual buffer, so the client then know how much data needs to actually receive for that one packet
                // receiving data size to know much data we need to receive
                int rec = socket.Receive(sizeBuf, 0, sizeBuf.Length, 0);
                if (rec <= 0)
                {
                    throw new SocketException();
                }
                // converting it back to an integer
                int size = BitConverter.ToInt32(sizeBuf, 0);
                // this will hold the data or the buffers that we receive
                MemoryStream ms = new MemoryStream(size);
                while (size > 0)
                {
                    // this is doing a check to see if the size is less than buffer size
                    // for eg, if buffer size is 20 and we send 30, since 30 > 20, it will use buffer = new byte[accept.ReceiveBufferSize];
                    // which will be 20, so it will receive 20 bytes at one time
                    // and then, when it receives it again, the size will be 10 and that will be less than buffer size 
                    // so, it will just receive the 10 bytes that are remaining
                    byte[] buffer;
                    if (size < socket.ReceiveBufferSize)
                    {
                        buffer = new byte[size];
                    }
                    else
                    {
                        buffer = new byte[socket.ReceiveBufferSize];
                    }
                    int received = socket.Receive(buffer, 0, buffer.Length, 0);
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
                MessageBox.Show("DISCONNECTED FROM CLIENT!");
                socket.Close();
                break;
            }
        }
        Application.Exit();
    }

    private void richTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    private void ClientForm_Load(object sender, EventArgs e)
    {

    }
}