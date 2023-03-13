using GildedRoseKata;

namespace GildedRoseTests;

public class ItemBuilder
{
    private string _name;
    private int _sellIn;
    private int _quality;

    public ItemBuilder WithSellIn(int sellIn)
    {
        _sellIn = sellIn;
        
        return this;
    }

    public ItemBuilder WithQuality(int quality)
    {
        _quality = quality;

        return this;
    }

    public ItemBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public Item Build() => new()
    {
        Name = _name,
        SellIn = _sellIn,
        Quality = _quality,
    };
}
