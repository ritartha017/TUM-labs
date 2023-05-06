namespace GoodExample;

class HtmlPrinter : IPrinter
{
    public void Print(string text)
    {
        Console.WriteLine("Printing on html...");
    }
}