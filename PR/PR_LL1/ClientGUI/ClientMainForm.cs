using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientGUI;

public partial class ClientMainForm : Form
{
    Socket sock;

    static Socket Socket()
    {
        return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public ClientMainForm()
    {
        InitializeComponent();
        sock = Socket();
        FormClosing += new FormClosingEventHandler(ClientMainForm_FormClosing);
    }

    private void ClientMainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        sock.Close();
    }

    private void ConnectBtn_Click(object sender, EventArgs e)
    {
        try
        {
            sock.Connect(new IPEndPoint(IPAddress.Parse(connectTextBox.Text), 3));
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

    private void Read()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[255];
                int rec = sock.Receive(buffer, 0, buffer.Length, 0);

                if (rec <= 0)
                {
                    throw new SocketException();
                }

                Array.Resize(ref buffer, rec);

                Invoke((MethodInvoker)delegate
                {
                    listBox.Items.Add(Encoding.Default.GetString(buffer));
                });
            }
            catch
            {
                MessageBox.Show("DISCONNECTED FROM CLIENT!");
                sock.Close();
                break;
            }
        }
        Application.Exit();
    }

    private void SendBackBtn_Click(object sender, EventArgs e)
    {
        byte[] data = Encoding.Default.GetBytes(sendBackTextBox.Text);
        sock.Send(data, 0, data.Length, 0);
    }

    private void ClientMainForm_Load(object sender, EventArgs e)
    {

    }

    private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}