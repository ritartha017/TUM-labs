using GildedRoseKata.Strategies;

namespace GildedRoseKata.Factory;

public class ItemStrategyFactory
{
    public IItemStrategy _strategy;

    public static IItemStrategy GetItemInstance(string itemName)
    {
        return itemName switch
        {
            "Aged Brie" => new AgedBrieStrategy(),
            "Backstage passes to a TAFKAL80ETC concert" => new BackStagePassesStrategy(),
            "Sulfuras, Hand of Ragnaros" => new SulfurasStrategy(),
            "Conjured Mana Cake" => new ConjuredStrategy(),
            _ => new StandardStrategy(),
        };
    }

    public void UpdateItem(Item item)
    {
        _strategy.UpdateItem(item);
    }
}
