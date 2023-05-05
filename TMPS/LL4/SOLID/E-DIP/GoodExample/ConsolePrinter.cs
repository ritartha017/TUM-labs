namespace GoodExample;

class ConsolePrinter : IPrinter
{
    public void Print(string text)
    {
        Console.WriteLine("Printing on console..");
    }
}