namespace AdapterPattern.Adapter;

using AdapterPattern.Adaptee;
using AdapterPattern.Target;

class MACAdapter : IComputer
{
    MAC mac;

    public MACAdapter(MAC mac)
    {
        this.mac = mac;
    }

    public void InsertIntoHDMIPort()
    {
        Console.WriteLine("Adapter converts HDMI signal to type C.");
        mac.InsertIntoUSBPort();
    }
}