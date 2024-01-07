using GildedRoseKata;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests;

public class The_Quality_Of_A_Normal_Item
{
    [TestCase("normal item", 10, 20)]
    [TestCase("normal item", 5, 7)]
    [TestCase("normal item", 3, 6)]
    [TestCase("normal item", 3, 5)]
    [TestCase("normal item", 2, 6)]
    [TestCase("normal item", 1, 7)]
    [TestCase("normal item", 1, 1)]
    public void Decreases_By_1_Every_Day_Before_The_Sell_By_Date_Has_Passed(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.SellIn, Is.GreaterThanOrEqualTo(0), "{0} date has passed. {0} = {1}", new[] { nameof(item.SellIn), item.SellIn.ToString() });
        Assert.That(item.Quality, Is.EqualTo(quality - 1), "{0} did not decrease by 1. {0} = {1}", new[] { nameof(item.Quality), item.Quality.ToString() });
    }

    [TestCase("normal item", 0, 5)]
    [TestCase("normal item", -1, 6)]
    [TestCase("normal item", -2, 7)]
    public void Decreases_Twice_As_Fast_Once_The_Sell_By_Date_Has_Passed(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.SellIn, Is.LessThan(0), "{0} date has not passed. {0} = {1}", new[] { nameof(item.SellIn), item.SellIn.ToString() });
        Assert.That(item.Quality, Is.EqualTo(quality - 2), "{0} did not decrease by 2. {0} = {1}", new[] { nameof(item.Quality), item.Quality.ToString() });
    }

    [TestCase("normal item", 10, 20)]
    [TestCase("normal item", 5, 7)]
    [TestCase("normal item", 3, 6)]
    [TestCase("normal item", 3, 5)]
    [TestCase("normal item", 2, 4)]
    [TestCase("normal item", 1, 0)]
    [TestCase("normal item", 0, 1)]
    public void Is_Never_Negative(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.GreaterThanOrEqualTo(0), "{0} is negative", new[] { nameof(item.Quality) });
    }

    [TestCase("normal item", 10, 20)]
    [TestCase("normal item", 5, 7)]
    [TestCase("normal item", 3, 6)]
    [TestCase("normal item", 3, 48)]
    [TestCase("normal item", 2, 49)]
    [TestCase("normal item", 1, 50)]
    [TestCase("normal item", 0, 51)]
    public void Is_Never_More_Than_50(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.LessThanOrEqualTo(50), "{0} is more than 50", new[] { nameof(item.Quality) });
    }
}

public class The_Quality_Of_Aged_Brie
{
    [TestCase("Aged Brie", 2, 0)]
    [TestCase("Aged Brie", 3, 5)]
    [TestCase("Aged Brie", 2, 6)]
    [TestCase("Aged Brie", 1, 7)]
    [TestCase("Aged Brie", 1, 1)]
    public void Increases_By_1_Every_Day_Before_The_Sell_By_Date_Has_Passed(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.SellIn, Is.GreaterThanOrEqualTo(0), "{0} date has passed. {0} = {1}", new[] { nameof(item.SellIn), item.SellIn.ToString() });
        Assert.That(item.Quality, Is.EqualTo(quality + 1), "{0} did not increase by 1. {0} = {1}", new[] { nameof(item.Quality), item.Quality.ToString() });
    }

    [TestCase("Aged Brie", 0, 5)]
    [TestCase("Aged Brie", -1, 6)]
    [TestCase("Aged Brie", -2, 7)]
    public void Increases_Twice_As_Fast_Once_The_Sell_By_Date_Has_Passed(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.SellIn, Is.LessThan(0), "{0} date has not passed. {0} = {1}", new[] { nameof(item.SellIn), item.SellIn.ToString() });
        Assert.That(item.Quality, Is.EqualTo(quality + 2), "{0} did not increase by 2. {0} = {1}", new[] { nameof(item.Quality), item.Quality.ToString() });
    }

    [TestCase("Aged Brie", 10, 20)]
    [TestCase("Aged Brie", 5, 7)]
    [TestCase("Aged Brie", 3, 6)]
    [TestCase("Aged Brie", 0, 5)]
    [TestCase("Aged Brie", 3, 48)]
    [TestCase("Aged Brie", 2, 49)]
    [TestCase("Aged Brie", 1, 50)]
    [TestCase("Aged Brie", 0, 48)]
    public void Is_Never_More_Than_50(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.LessThanOrEqualTo(50), "{0} is more than 50", new[] { nameof(item.Quality) });
    }
}

public class The_Quality_Of_Backstage_Passes
{
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 14, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 13, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 12, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 11, 0)]
    public void Increases_By_1_When_There_Are_More_Than_10_Days_Before_The_Concert(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(quality + 1), "{0} did not increase by 1. {0} = {1}", new[] { nameof(item.Quality), item.Quality.ToString() });
    }

    [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 9, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 8, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 7, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 6, 0)]
    public void Increases_By_2_When_There_Are_Between_10_Days_And_6_Days_Before_The_Concert(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(quality + 2), "{0} did not increase by 2. {0} = {1}", new[] { nameof(item.Quality), item.Quality.ToString() });
    }

    [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 4, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 3, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 2, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 1, 0)]
    public void Increases_By_3_When_There_Are_5_Days_Or_Less_Before_The_Concert(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(quality + 3), "{0} did not increase by 3. {0} = {1}", new[] { nameof(item.Quality), item.Quality.ToString() });
    }

    [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 20)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", -1, 20)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", -2, 20)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", -3, 20)]
    public void Drops_To_0_After_The_Concert(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(0), "{0} is not 0", new[] { nameof(item.Quality) });
    }

    [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 49)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 49)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 20)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 7)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 3, 6)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 5)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 3, 48)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 2, 49)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 1, 50)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 48)]
    public void Is_Never_More_Than_50(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.LessThanOrEqualTo(50), "{0} is more than 50", new[] { nameof(item.Quality) });
    }
}

public class The_Quality_Of_A_Legendary_Item
{
    [TestCase("Sulfuras, Hand of Ragnaros", 0, 80)]
    [TestCase("Sulfuras, Hand of Ragnaros", -1, 80)]
    [TestCase("Sulfuras, Hand of Ragnaros", 0, 50)]
    [TestCase("Sulfuras, Hand of Ragnaros", 0, 40)]
    [TestCase("Sulfuras, Hand of Ragnaros", 0, 30)]
    public void Never_Changes(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(quality), "{0} has changed", new[] { nameof(item.Quality) });
    }

    [TestCase("Sulfuras, Hand of Ragnaros", 0, 80)]
    [TestCase("Sulfuras, Hand of Ragnaros", -1, 80)]
    public void Is_80_And_Never_Alters(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.Quality, Is.EqualTo(80), "{0} is not 80", new[] { nameof(item.Quality) });
    }
}

public class The_Quality_Of_A_Conjured_Item
{
    [TestCase("Conjured Mana Cake", 3, 6)]
    [TestCase("Conjured Armour", 2, 5)]
    [TestCase("Conjured Root Beer", 1, 3)]
    public void Degrades_Twice_As_Fast_As_Normal_Items_Before_The_Sell_By_Date_Has_Passed(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.SellIn, Is.GreaterThanOrEqualTo(0), "{0} date has passed. {0} = {1}", new[] { nameof(item.SellIn), item.SellIn.ToString() });
        Assert.That(item.Quality, Is.EqualTo(quality - 2), "{0} did not degrade twice as fast", new[] { nameof(item.Quality) });
    }

    [TestCase("Conjured Mana Cake", 0, 6)]
    [TestCase("Conjured Armour", -1, 10)]
    [TestCase("Conjured Root Beer", -2, 9)]
    public void Degrades_Twice_As_Fast_As_Normal_Items_Once_The_Sell_By_Date_Has_Passed(string name, int sellIn, int quality)
    {
        Item item = new() { Name = name, SellIn = sellIn, Quality = quality };
        var app = new GildedRose(new List<Item> { item });

        app.UpdateQuality();

        Assert.That(item.SellIn, Is.LessThan(0), "{0} date has not passed. {0} = {1}", new[] { nameof(item.SellIn), item.SellIn.ToString() });
        Assert.That(item.Quality, Is.EqualTo(quality - 4), "{0} did not degrade twice as fast", new[] { nameof(item.Quality) });
    }
}
