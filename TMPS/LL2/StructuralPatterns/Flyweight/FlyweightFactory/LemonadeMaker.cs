namespace Flyweight.FlyweightFactory;

using System;
using System.Collections.Generic;

using Flyweight.ConcreteFlyweights;
using Flyweight.FlyweightInterface;

class LemonadeMaker
{
    private readonly Dictionary<string, ILemonade> availableLemonades = new();
    public ILemonade? GetLemonade(string lemonadeFlavor)
    {
        if (availableLemonades.ContainsKey(lemonadeFlavor))
        {
            Console.WriteLine("Lemonade reuse"); ;
            return availableLemonades[lemonadeFlavor];
        }

        Console.WriteLine("Making a new lemonade..");
        switch (lemonadeFlavor)
        {
            case "lemon":
                availableLemonades[lemonadeFlavor] = new ClassicLemonade();
                return availableLemonades[lemonadeFlavor];
            case "cherry":
                availableLemonades[lemonadeFlavor] = new CherryLemonade();
                return availableLemonades[lemonadeFlavor];
        }
        return null;
    }
}
