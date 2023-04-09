using AdapterPattern.Target;

namespace AdapterPattern.Adaptee;

class MAC
{
    public void InsertIntoUSBPort()
    {
        Console.WriteLine("USB connector is plugged into a mac machine.");
    }
}
