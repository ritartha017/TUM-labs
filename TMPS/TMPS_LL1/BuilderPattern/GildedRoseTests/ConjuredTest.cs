using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests;

public class ConjuredTest
{
    private const string Conjured = "Conjured Mana Cake";

    [Fact]
    public void Conjured_DecreasesInQuality_TwiceTheSpeed()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(Conjured)
            .WithSellIn(3)
            .WithQuality(6)
            .Build()
        };
        
        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(Conjured)
            .WithSellIn(2)
            .WithQuality(4)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void Conjured_DecreasesInQuality_TwiceTheSpeed_AlsoWhenSellInExpired()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(Conjured)
            .WithSellIn(0)
            .WithQuality(6)
            .Build()
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(Conjured)
            .WithSellIn(-1)
            .WithQuality(2)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }
}
