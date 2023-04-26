using System;

namespace GildedRoseKata;

// Concrete classes have to implement all abstract operations of
// the base class but they must not override the template method
// itself.
public class AgedBrie : InventoryItem
{
    public const string ITEM_NAME = "Aged Brie";

    public AgedBrie(Item item) : base(item)
    {
    }

    // Subclasses can also override some operations with a default
    // implementation.
    protected override void ProcessExpired()
    {
        Console.WriteLine("AgedBrie process expired implementation.");
        IncreaseQuality();
    }

    protected override void UpdateQuality()
    {
        Console.WriteLine("AgedBrie update quality implementation.");
        IncreaseQuality();
    }
}