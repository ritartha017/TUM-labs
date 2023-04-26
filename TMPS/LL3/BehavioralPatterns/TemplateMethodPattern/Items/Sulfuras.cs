using System;

namespace GildedRoseKata;

public class Sulfuras : InventoryItem
{
    public const string ITEM_NAME = "Sulfuras, Hand of Ragnaros";

    public Sulfuras(Item item) : base(item)
    {
    }

    protected override void UpdateQuality()
    {
        Console.WriteLine("Sulfuras update quality implementation.");
    }

    protected override void UpdateExpiration()
    {
        Console.WriteLine("Sulfuras update expiration implementation.");
    }

    protected override void ProcessExpired()
    {
        Console.WriteLine("Sulfuras process expired implementation.");
    }
}
