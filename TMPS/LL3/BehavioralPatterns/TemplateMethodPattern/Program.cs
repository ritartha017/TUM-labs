using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        IList<Item> Items = new List<Item>{
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        var app = new GildedRose(Items);

        // test aged brie item
        int i = 0;
        Console.WriteLine("-------- day " + i + " --------");
        Console.WriteLine("name, sellIn, quality");

        var itemAgedBrie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
        Console.WriteLine(itemAgedBrie.Name + ", " + itemAgedBrie.SellIn + ", " + itemAgedBrie.Quality);

        InventoryItem inventoryItem = InventoryItem.Create(itemAgedBrie);
        inventoryItem.DailyUpdate();

        Console.WriteLine("\n-------- day " + ++i + " --------");
        Console.WriteLine(itemAgedBrie.Name + ", " + itemAgedBrie.SellIn + ", " + itemAgedBrie.Quality);

        Console.WriteLine("\n\n\n");


        // test sulfuras item
        i = 0;
        Console.WriteLine("-------- day " + i + " --------");
        Console.WriteLine("name, sellIn, quality");

        var itemSulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 };
        Console.WriteLine(itemSulfuras.Name + ", " + itemSulfuras.SellIn + ", " + itemSulfuras.Quality);

        inventoryItem = InventoryItem.Create(itemSulfuras);
        inventoryItem.DailyUpdate();

        Console.WriteLine("\n-------- day " + ++i + " --------");
        Console.WriteLine(itemSulfuras.Name + ", " + itemSulfuras.SellIn + ", " + itemSulfuras.Quality);

        Console.ReadKey();

        //for (var i = 0; i < 31; i++)
        //{
        //    Console.WriteLine("-------- day " + i + " --------");
        //    Console.WriteLine("name, sellIn, quality");
        //    for (var j = 0; j < Items.Count; j++)
        //    {
        //        System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
        //    }
        //    Console.WriteLine("");
        //    app.UpdateQuality();
        //}
    }
}
