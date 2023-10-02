using System.Net;
using System.Net.Sockets;

namespace Common.Data;

public class SocketInfo
{
    public const int BUFF_SIZE = 1024;

    public EndPoint EndPoint { get; set; }

    public string Ip { get; set; }

    public int Port { get; set; }

    public string Topic { get; set; }

    public Socket Socket { get; set; }

    public byte[] Data { get; set; }

    public SocketInfo()
    {
        Data = new byte[1024];
    }
}