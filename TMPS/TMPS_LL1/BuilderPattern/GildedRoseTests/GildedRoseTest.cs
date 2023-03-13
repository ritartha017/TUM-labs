using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private const string ItemName = "MyAwesomeItemName";

    [Fact]
    public void SellInDateDecreases_ButQualityCannotBeNegative()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(ItemName)
            .WithSellIn(0)
            .WithQuality(0)
            .Build()
        };
        
        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(ItemName)
            .WithSellIn(-1)
            .WithQuality(0)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void QualityDecreases()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(ItemName)
            .WithSellIn(10)
            .WithQuality(10)
            .Build()
        };
        
        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(ItemName)
            .WithSellIn(9)
            .WithQuality(9)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void QualityDecreases_ButTwiceFasterAfterSellInDateExpired()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(ItemName)
            .WithSellIn(0)
            .WithQuality(10)
            .Build()
        };
        
        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(ItemName)
            .WithSellIn(-1)
            .WithQuality(8)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }
}

