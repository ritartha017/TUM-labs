using System.Net.Sockets;

namespace MultiConBroker.Models;

public class Subscriber
{
	public string Topic { get; set; }

	public string Address { get; set; }

	public Socket Socket { get; set; }

	public Subscriber()
	{

	}
}