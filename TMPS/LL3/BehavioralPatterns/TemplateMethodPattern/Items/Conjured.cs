using System;

namespace GildedRoseKata;

public class Conjured : InventoryItem
{
    public const string ITEM_NAME = "Conjured Mana Cake";

    public Conjured(Item item) : base(item)
    {
    }

    protected override void UpdateQuality()
    {
        Console.WriteLine("Conjured update quality implementation.");
        DecreaseQuality();
        DecreaseQuality();
    }

    protected override void ProcessExpired()
    {
        Console.WriteLine("Conjured process expired implementation.");
        DecreaseQuality();
        DecreaseQuality();
    }
}
