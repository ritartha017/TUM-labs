using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests;

public class SulfurasTest
{
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

    [Fact]
    public void SulfurasNeverChanges()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(Sulfuras)
            .WithSellIn(2)
            .WithQuality(80)
            .Build()
        };
        
        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(Sulfuras)
            .WithSellIn(2)
            .WithQuality(80)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }
}
