using System;

namespace GildedRoseKata;

public class BackstagePasses : InventoryItem
{
    public const string ITEM_NAME = "Backstage passes to a TAFKAL80ETC concert";

    public BackstagePasses(Item item) : base(item)
    {
    }

    protected override void ProcessExpired()
    {
        Console.WriteLine("BackstagePasses process expired implementation.");
        item.Quality = 0;
    }

    protected override void UpdateQuality()
    {
        Console.WriteLine("BackstagePasses update quality implementation.");
        IncreaseQuality();

        if (item.SellIn < 11)
        {
            IncreaseQuality();
        }

        if (item.SellIn < 6)
        {
            IncreaseQuality();
        }
    }
}
