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
        Assert.That(item.Quality, Is.EqualTo(quality-1), "{0} did not decrease by 1. {0} = {1}", new[] { nameof(item.Quality), item.Quality.ToString() });
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
