namespace GoodExample.Concrete;

using System;
using GoodExample.Abstract;

class PotatoMeal : MealBase
{
    protected override void Cook()
    {
        Console.WriteLine("Putting the peeled potatoes on the fire..");
        Console.WriteLine("Сook for about 30 minutes...");
        Console.WriteLine("Draining the remaining water, mash the boiled potatoes into a puree..");
    }

    protected override void FinalSteps()
    {
        Console.WriteLine("Sprinkle puree with spices and herbs..");
        Console.WriteLine("Potato puree are ready.");
    }

    protected override void Prepare()
    {
        Console.WriteLine("Peeling and washing potatoes..");
    }
}
