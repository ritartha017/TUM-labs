using System;

namespace GildedRoseKata;

// The abstract class defines a template method that contains a skeleton of some algorithm composed of calls, usually to
// abstract primitive operations. Concrete subclasses implement these operations, but leave the template method itself
// intact.
public abstract class InventoryItem
{
    protected Item item;

    public static InventoryItem Create(Item item)
    {
        return InventoryItemFactory.GetItem(item);
    }

    public InventoryItem(Item item)
    {
        this.item = item;
    }

    // The template method defines the skeleton of an algorithm.
    public void DailyUpdate()
    {
        UpdateQuality();
        UpdateExpiration();

        if (IsExpired())
        {
            ProcessExpired();
        }
    }

    // And some of them may be defined as abstract or virtual.
    protected virtual void UpdateQuality()
    {
        Console.WriteLine("Default update quality implementation.");
        DecreaseQuality();
    }

    protected virtual void UpdateExpiration()
    {
        Console.WriteLine("Default update expiration implementation.");
        item.SellIn--;
    }

    protected bool IsExpired()
    {
        return item.SellIn < 0;
    }

    protected virtual void ProcessExpired()
    {
        Console.WriteLine("Default process expired implementation.");
        DecreaseQuality();
    }

    protected void IncreaseQuality()
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }
    }
    protected void DecreaseQuality()
    {
        if (item.Quality > 0)
        {
            item.Quality--;
        }
    }
}