namespace GoodExample.Concrete;

using System;
using GoodExample.Abstract;

class SaladMeal : MealBase
{
    protected override void Cook()
    {
        Console.WriteLine("Cut tomatoes and cucumbers...");
        Console.WriteLine("Sprinkle with herbs, salt and spices...");
    }

    protected override void FinalSteps()
    {
        Console.WriteLine("Drizzle with oil...");
        Console.WriteLine("The salad is ready.");
    }

    protected override void Prepare()
    {
        Console.WriteLine("Washing tomatoes and cucumbers...");
    }
}
