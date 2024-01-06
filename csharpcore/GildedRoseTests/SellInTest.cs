using GildedRoseKata;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests;

public class The_SellIn_Of_A_Non_Legendary_Item
{
    [TestCase("normal item", 10, 20)]
    [TestCase("normal item", 5, 7)]
    [TestCase("normal item", 3, 6)]
    [TestCase("Aged Brie", 3, 5)]
    [TestCase("Aged Brie", 2, 6)]
    [TestCase("normal item", 1, 7)]
    [TestCase("normal item", 1, 1)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 1)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", -1, 1)]
    [TestCase("normal item", -2, 1)]
    public void Decreases_By_1_Every_Day(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Name, Is.Not.EqualTo("Sulfuras, Hand of Ragnaros"), "{0} is legendary. {0} = {1}", new[] { nameof(item.Name), item.Name });
        Assert.That(item.SellIn, Is.EqualTo(sellIn - 1), "{0} has not decreased by 1. {0} = {1}", new[] { nameof(item.SellIn), item.SellIn.ToString() });
    }
}

public class The_SellIn_Of_A_Legendary_Item
{
    [TestCase("Sulfuras, Hand of Ragnaros", 10, 20)]
    [TestCase("Sulfuras, Hand of Ragnaros", 5, 7)]
    [TestCase("Sulfuras, Hand of Ragnaros", 3, 6)]
    [TestCase("Sulfuras, Hand of Ragnaros", 3, 5)]
    [TestCase("Sulfuras, Hand of Ragnaros", 2, 6)]
    [TestCase("Sulfuras, Hand of Ragnaros", 1, 7)]
    [TestCase("Sulfuras, Hand of Ragnaros", 1, 1)]
    [TestCase("Sulfuras, Hand of Ragnaros", 0, 1)]
    [TestCase("Sulfuras, Hand of Ragnaros", -1, 1)]
    [TestCase("Sulfuras, Hand of Ragnaros", -2, 1)]
    public void Never_Changes(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"), "{0} is not legendary. {0} = {1}", new[] { nameof(item.Name), item.Name });
        Assert.That(item.SellIn, Is.EqualTo(sellIn), "{0} has changed. {0} = {1}", new[] { nameof(item.SellIn), item.SellIn.ToString() });
    }
}
