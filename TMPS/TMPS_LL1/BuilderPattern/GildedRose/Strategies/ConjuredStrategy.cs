namespace GildedRoseKata.Strategies;

public class ConjuredStrategy : IItemStrategy
{
    public void UpdateItem(Item item)
    {
        item.SellIn--;

        if (item.SellIn < 0) item.Quality -= 4;

        if (item.SellIn > 0) item.Quality -= 2;
    }
}
