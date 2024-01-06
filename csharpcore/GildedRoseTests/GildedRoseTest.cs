using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.AreEqual("foo", items[0].Name);
    }

    [Test]
    public void Original_Test_Case()
    {
        var vest = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
        var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
        var elixir = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 };
        var sulfuras1 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
        var sulfuras2 = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 };
        var pass1 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
        var pass2 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 };
        var pass3 = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 };
        var cake = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
        var items = new List<Item>{
            vest,
            brie,
            elixir,
            sulfuras1,
            sulfuras2,
            pass1,
            pass2,
            pass3,
            cake
        };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.AreEqual("+5 Dexterity Vest", vest.Name, "{0} {1} is not equal.", new[] { nameof(vest), nameof(vest.Name) });
        Assert.AreEqual(9, vest.SellIn, "{0} {1} is not equal.", new[] { nameof(vest), nameof(vest.SellIn) });
        Assert.AreEqual(19, vest.Quality, "{0} {1} is not equal.", new[] { nameof(vest), nameof(vest.Quality) });

        Assert.AreEqual("Aged Brie", brie.Name, "{0} {1} is not equal.", new[] { nameof(brie), nameof(brie.Name) });
        Assert.AreEqual(1, brie.SellIn, "{0} {1} is not equal.", new[] { nameof(brie), nameof(brie.SellIn) });
        Assert.AreEqual(1, brie.Quality, "{0} {1} is not equal.", new[] { nameof(brie), nameof(brie.Quality) });

        Assert.AreEqual("Elixir of the Mongoose", elixir.Name, "{0} {1} is not equal.", new[] { nameof(elixir), nameof(elixir.Name) });
        Assert.AreEqual(4, elixir.SellIn, "{0} {1} is not equal.", new[] { nameof(elixir), nameof(elixir.SellIn) });
        Assert.AreEqual(6, elixir.Quality, "{0} {1} is not equal.", new[] { nameof(elixir) , nameof(elixir.Quality) });

        Assert.AreEqual("Sulfuras, Hand of Ragnaros", sulfuras1.Name, "{0} {1} is not equal.", new[] { nameof(sulfuras1), nameof(sulfuras1.Name) });
        Assert.AreEqual(0, sulfuras1.SellIn, "{0} {1} is not equal.", new[] { nameof(sulfuras1) , nameof(sulfuras1.SellIn) });
        Assert.AreEqual(80, sulfuras1.Quality, "{0} {1} is not equal.", new[] { nameof(sulfuras1) , nameof(sulfuras1.Quality) });

        Assert.AreEqual("Sulfuras, Hand of Ragnaros", sulfuras2.Name, "{0} {1} is not equal.", new[] { nameof(sulfuras2) , nameof(sulfuras2.Name) });
        Assert.AreEqual(-1, sulfuras2.SellIn, "{0} {1} is not equal.", new[] { nameof(sulfuras2) , nameof(sulfuras2.SellIn) });
        Assert.AreEqual(80, sulfuras2.Quality, "{0} {1} is not equal.", new[] { nameof(sulfuras2) , nameof(sulfuras2.Quality) });

        Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", pass1.Name, "{0} {1} is not equal.", new[] { nameof(pass1), nameof(pass1.Name) });
        Assert.AreEqual(14, pass1.SellIn, "{0} {1} is not equal.", new[] { nameof(pass1) , nameof(pass1.SellIn) });
        Assert.AreEqual(21, pass1.Quality, "{0} {1} is not equal.", new[] { nameof(pass1) , nameof(pass1.Quality) });

        Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", pass2.Name, "{0} {1} is not equal.", new[] { nameof(pass2), nameof(pass2.Name) });
        Assert.AreEqual(9, pass2.SellIn, "{0} {1} is not equal.", new[] { nameof(pass2) , nameof(pass2.SellIn) });
        Assert.AreEqual(50, pass2.Quality, "{0} {1} is not equal.", new[] { nameof(pass2) , nameof(pass2.Quality) });

        Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", pass3.Name, "{0} {1} is not equal.", new[] { nameof(pass3) , nameof(pass3.Name) });
        Assert.AreEqual(4, pass3.SellIn, "{0} {1} is not equal.", new[] { nameof(pass3) , nameof(pass3.SellIn) });
        Assert.AreEqual(50, pass3.Quality, "{0} {1} is not equal.", new[] { nameof(pass3) , nameof(pass3.Quality) });

        Assert.AreEqual("Conjured Mana Cake", cake.Name, "{0} {1} is not equal.", new[] { nameof(cake) , nameof(cake.Name) });
        Assert.AreEqual(2, cake.SellIn, "{0} {1} is not equal.", new[] { nameof(cake) , nameof(cake.SellIn) });
        Assert.AreEqual(5, cake.Quality, "{0} {1} is not equal.", new[] { nameof(cake) , nameof(cake.Quality) });
    }
}