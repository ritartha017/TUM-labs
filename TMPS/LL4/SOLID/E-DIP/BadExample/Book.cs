namespace BadExample;

class Book
{
public string Text { get; set; }
public ConsolePrinter Printer { get; set; }

public void Print()
{
    Printer.Print(Text);
}
}