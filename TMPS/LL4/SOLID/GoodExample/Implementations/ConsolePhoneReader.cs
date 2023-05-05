namespace GoodExample.Implementations;

using System;

class ConsolePhoneReader : IPhoneReader
{
    public string?[] GetInputData()
    {
        Console.WriteLine("Enter phone model::");
        string? model = Console.ReadLine();
        Console.WriteLine("Enter cost");
        string? price = Console.ReadLine();
        return new string?[] { model, price };
    }
}
