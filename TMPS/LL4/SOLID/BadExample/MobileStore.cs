namespace BadExample;

using System;
using System.Collections.Generic;

class MobileStore
{
    List<Phone> phones = new();
    public void Process()
    {
        Console.WriteLine("Enter phone model:");
        string? model = Console.ReadLine();
        Console.WriteLine("Enter cost:");

        bool result = int.TryParse(Console.ReadLine(), out var price);

        if (result == false || price <= 0 || string.IsNullOrEmpty(model))
        {
            throw new Exception("Incorrect input data.");
        }
        else
        {
            phones.Add(new Phone(model, price));
            using (StreamWriter writer = new StreamWriter("store.txt", true))
            {
                writer.WriteLine(model);
                writer.WriteLine(price);
            }
            Console.WriteLine("Successfully processed.");
        }
    }
}
