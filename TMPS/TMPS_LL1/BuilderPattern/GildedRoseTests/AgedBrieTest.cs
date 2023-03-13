using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests;

public class AgedBrieTest
{
    private const string AgedBrie = "Aged Brie";

    [Fact]
    public void AgedBrie_IncreasesInQuality()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(AgedBrie)
            .WithSellIn(2)
            .WithQuality(2)
            .Build() 
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(AgedBrie)
            .WithSellIn(1)
            .WithQuality(3)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void AgedBrie_CannotGoOver50Quality()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(AgedBrie)
            .WithSellIn(2)
            .WithQuality(50)
            .Build() 
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(AgedBrie)
            .WithSellIn(1)
            .WithQuality(50)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void AgedBrie_IncreasesInQuality_ByOneOutside10Days()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(AgedBrie)
            .WithSellIn(20)
            .WithQuality(2)
            .Build()
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(AgedBrie)
            .WithSellIn(19)
            .WithQuality(3)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void AgedBrie_IncreasesInQuality_DoublesWhenOff()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(AgedBrie)
            .WithSellIn(0)
            .WithQuality(2)
            .Build()
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(AgedBrie)
            .WithSellIn(-1)
            .WithQuality(4)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }
}
