using GildedRoseKata.Factory;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> Items;
	
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            var context = ItemStrategyFactory.GetItemInstance(item.Name);
            context.UpdateItem(item);
        }
    }

    public IList<Item> GetItems() => Items;
}
