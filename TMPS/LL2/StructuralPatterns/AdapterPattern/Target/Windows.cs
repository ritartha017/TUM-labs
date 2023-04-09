namespace AdapterPattern.Target;

class Windows : IComputer
{
    public void InsertIntoHDMIPort()
    {
        Console.WriteLine("HDMI connector is plugged into windows machine.");
    }
}
