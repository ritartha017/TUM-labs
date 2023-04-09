using AdapterPattern.Target;

namespace AdapterPattern.Client;

class User
{
    public void InsertHDMIConnectorIntoComputer(IComputer computer)
    {
        Console.WriteLine("Client inserts HDMI connector into computer.");
        computer.InsertIntoHDMIPort();
    }
}
