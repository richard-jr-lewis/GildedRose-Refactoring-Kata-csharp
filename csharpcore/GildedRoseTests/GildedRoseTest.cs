using GildedRoseKata;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
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

        Assert.That(vest.Name, Is.EqualTo("+5 Dexterity Vest"), "{0} {1} is not equal.", new[] { nameof(vest), nameof(vest.Name) });
        Assert.That(vest.SellIn, Is.EqualTo(9), "{0} {1} is not equal.", new[] { nameof(vest), nameof(vest.SellIn) });
        Assert.That(vest.Quality, Is.EqualTo(19), "{0} {1} is not equal.", new[] { nameof(vest), nameof(vest.Quality) });

        Assert.That(brie.Name, Is.EqualTo("Aged Brie"), "{0} {1} is not equal.", new[] { nameof(brie), nameof(brie.Name) });
        Assert.That(brie.SellIn, Is.EqualTo(1), "{0} {1} is not equal.", new[] { nameof(brie), nameof(brie.SellIn) });
        Assert.That(brie.Quality, Is.EqualTo(1), "{0} {1} is not equal.", new[] { nameof(brie), nameof(brie.Quality) });

        Assert.That(elixir.Name, Is.EqualTo("Elixir of the Mongoose"), "{0} {1} is not equal.", new[] { nameof(elixir), nameof(elixir.Name) });
        Assert.That(elixir.SellIn, Is.EqualTo(4), "{0} {1} is not equal.", new[] { nameof(elixir), nameof(elixir.SellIn) });
        Assert.That(elixir.Quality, Is.EqualTo(6), "{0} {1} is not equal.", new[] { nameof(elixir), nameof(elixir.Quality) });

        Assert.That(sulfuras1.Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"), "{0} {1} is not equal.", new[] { nameof(sulfuras1), nameof(sulfuras1.Name) });
        Assert.That(sulfuras1.SellIn, Is.EqualTo(0), "{0} {1} is not equal.", new[] { nameof(sulfuras1), nameof(sulfuras1.SellIn) });
        Assert.That(sulfuras1.Quality, Is.EqualTo(80), "{0} {1} is not equal.", new[] { nameof(sulfuras1), nameof(sulfuras1.Quality) });

        Assert.That(sulfuras2.Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"), "{0} {1} is not equal.", new[] { nameof(sulfuras2), nameof(sulfuras2.Name) });
        Assert.That(sulfuras2.SellIn, Is.EqualTo(-1), "{0} {1} is not equal.", new[] { nameof(sulfuras2), nameof(sulfuras2.SellIn) });
        Assert.That(sulfuras2.Quality, Is.EqualTo(80), "{0} {1} is not equal.", new[] { nameof(sulfuras2), nameof(sulfuras2.Quality) });

        Assert.That(pass1.Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"), "{0} {1} is not equal.", new[] { nameof(pass1), nameof(pass1.Name) });
        Assert.That(pass1.SellIn, Is.EqualTo(14), "{0} {1} is not equal.", new[] { nameof(pass1), nameof(pass1.SellIn) });
        Assert.That(pass1.Quality, Is.EqualTo(21), "{0} {1} is not equal.", new[] { nameof(pass1), nameof(pass1.Quality) });

        Assert.That(pass2.Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"), "{0} {1} is not equal.", new[] { nameof(pass2), nameof(pass2.Name) });
        Assert.That(pass2.SellIn, Is.EqualTo(9), "{0} {1} is not equal.", new[] { nameof(pass2), nameof(pass2.SellIn) });
        Assert.That(pass2.Quality, Is.EqualTo(50), "{0} {1} is not equal.", new[] { nameof(pass2), nameof(pass2.Quality) });

        Assert.That(pass3.Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"), "{0} {1} is not equal.", new[] { nameof(pass3), nameof(pass3.Name) });
        Assert.That(pass3.SellIn, Is.EqualTo(4), "{0} {1} is not equal.", new[] { nameof(pass3), nameof(pass3.SellIn) });
        Assert.That(pass3.Quality, Is.EqualTo(50), "{0} {1} is not equal.", new[] { nameof(pass3), nameof(pass3.Quality) });

        Assert.That(cake.Name, Is.EqualTo("Conjured Mana Cake"), "{0} {1} is not equal.", new[] { nameof(cake), nameof(cake.Name) });
        Assert.That(cake.SellIn, Is.EqualTo(2), "{0} {1} is not equal.", new[] { nameof(cake), nameof(cake.SellIn) });
        Assert.That(cake.Quality, Is.EqualTo(5), "{0} {1} is not equal.", new[] { nameof(cake), nameof(cake.Quality) });
    }
}
