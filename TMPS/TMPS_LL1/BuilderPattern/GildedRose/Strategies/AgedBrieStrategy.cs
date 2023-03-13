namespace GildedRoseKata.Strategies;

public class AgedBrieStrategy : IItemStrategy
{
    public void UpdateItem(Item item)
    {
        item.SellIn--;

        if (item.Quality < 50) item.Quality++;

        if (item.SellIn < 0 && item.Quality < 50) item.Quality++;
    }
}
