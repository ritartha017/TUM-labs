using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests;

public class BackStagePassesTest
{
    private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";

    [Fact]
    public void BackStagePasses_IncreasesInQuality_ByOneOutside10Days()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(Backstage)
            .WithSellIn(20)
            .WithQuality(2)
            .Build()
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(Backstage)
            .WithSellIn(19)
            .WithQuality(3) 
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void BackStagePasses_IncreasesInQuality_ByTwoInside10Days()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(Backstage)
            .WithSellIn(10)
            .WithQuality(2)
            .Build()
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(Backstage)
            .WithSellIn(9)
            .WithQuality(4)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void BackStagePasses_IncreasesInQuality_ByThreeInside5Days()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(Backstage)
            .WithSellIn(5)
            .WithQuality(2)
            .Build()
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(Backstage)
            .WithSellIn(4)
            .WithQuality(5)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }

    [Fact]
    public void BackStagePasses_IncreasesInQuality_GoesToZeroWhenSellInExpires()
    {
        var Items = new List<Item> { new ItemBuilder()
            .WithName(Backstage)
            .WithSellIn(0)
            .WithQuality(20)
            .Build()
        };

        var app = new GildedRose(Items);
        var expected = new ItemBuilder()
            .WithName(Backstage)
            .WithSellIn(-1)
            .WithQuality(0)
            .Build();

        app.UpdateQuality();

        expected.Should().BeEquivalentTo(app.GetItems()[0]);
    }
}
