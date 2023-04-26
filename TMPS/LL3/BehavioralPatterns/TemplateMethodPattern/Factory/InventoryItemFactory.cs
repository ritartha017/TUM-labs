namespace GildedRoseKata;

public class InventoryItemFactory
{
    public static InventoryItem GetItem(Item item)
    {
        return item.Name switch
        {
            Sulfuras.ITEM_NAME => new Sulfuras(item),
            AgedBrie.ITEM_NAME => new AgedBrie(item),
            BackstagePasses.ITEM_NAME => new BackstagePasses(item),
            Conjured.ITEM_NAME => new Conjured(item),
            _ => new StandardItem(item)
        };
    }
}