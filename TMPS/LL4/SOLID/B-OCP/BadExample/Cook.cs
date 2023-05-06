namespace BadExample;

class Cook
{
    public string Name { get; set; }
    public Cook(string name)
    {
        this.Name = name;
    }

    public void MakeDinner()
    {
        Console.WriteLine("Peeling potatoes..");
        Console.WriteLine("Putting the peeled potatoes on the fire..");
        Console.WriteLine("Сook for about 30 minutes...");
        Console.WriteLine("Draining the remaining water, mash the boiled potatoes into a puree..");
        Console.WriteLine("Sprinkle puree with spices and herbs..");
        Console.WriteLine("Potato puree are ready.");
    }
}
