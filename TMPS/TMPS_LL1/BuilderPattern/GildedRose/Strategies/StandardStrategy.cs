namespace GildedRoseKata.Strategies;

public class StandardStrategy : IItemStrategy
{
    public void UpdateItem(Item item)
    {
        item.SellIn--;

        if (item.Quality > 0) item.Quality--;

        if (item.SellIn < 0 && item.Quality > 0) item.Quality--;
    }
}
