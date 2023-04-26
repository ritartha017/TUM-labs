using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    readonly IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            InventoryItem inventoryItem = InventoryItem.Create(item);
            inventoryItem.DailyUpdate();
        }
    }

    public IList<Item> GetItems()
    {
        return Items;
    }
}