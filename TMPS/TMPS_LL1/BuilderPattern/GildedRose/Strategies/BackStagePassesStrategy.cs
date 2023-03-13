namespace GildedRoseKata.Strategies;

public class BackStagePassesStrategy : IItemStrategy
{
    public void UpdateItem(Item item)
    {
        if (item.SellIn > 0 && item.Quality < 50) item.Quality++;

        if (item.SellIn <= 10 && item.Quality < 50) item.Quality++;

        if (item.SellIn <= 5 && item.Quality < 50) item.Quality++;

        item.SellIn--;

        if (item.SellIn < 0) item.Quality = 0;
    }
}