using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerGUI;

public partial class ServerMainForm : Form
{
    Socket sock;
    Socket accept;

    static Socket Socket()
    {
        return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public ServerMainForm()
    {
        InitializeComponent();
        sock = Socket();
        FormClosing += new FormClosingEventHandler(ServerMainForm_FormClosing);
    }

    private void ServerMainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        sock.Close();
    }

    private void ListenBtn_Click(object sender, EventArgs e)
    {
        sock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3));
        sock.Listen(0);

        new Thread(delegate()
        {
            accept = sock.Accept();
            MessageBox.Show("CONNECTED ACCEPTED!");
            sock.Close();

            Read();

        }).Start();
    }

    private void Read()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[255];
                int rec = accept.Receive(buffer, 0, buffer.Length, 0);

                if (rec <= 0)
                {
                    throw new SocketException();
                }

                Array.Resize(ref buffer, rec);

                // running this code on the main thread of the form
                Invoke((MethodInvoker)delegate
                {
                    listeningTextBox.Items.Add(Encoding.Default.GetString(buffer));
                });
            }
            catch
            {
                MessageBox.Show("DISCONNECTED FROM SERVER!");
                sock.Close();
                break;
            }
        }
        Application.Exit();
    }

    private void SendBtn_Click(object sender, EventArgs e)
    {
        byte[] data = Encoding.Default.GetBytes(sendTextBox.Text);
        accept.Send(data, 0, data.Length, 0);
    }

    private void ListeningTextBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void ServerMainForm_Load(object sender, EventArgs e)
    {

    }

    private void SendTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}