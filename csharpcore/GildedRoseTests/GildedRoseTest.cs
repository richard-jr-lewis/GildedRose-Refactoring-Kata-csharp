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

        Assert.That(items[0].Name, Is.EqualTo("foo"));
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

        Assert.Multiple(() =>
        {
            Assert.That(vest.Name, Is.EqualTo("+5 Dexterity Vest"), $"{nameof(vest)} {nameof(vest.Name)} is not equal.");
            Assert.That(vest.SellIn, Is.EqualTo(9), $"{nameof(vest)} {nameof(vest.SellIn)} is not equal.");
            Assert.That(vest.Quality, Is.EqualTo(19), $"{nameof(vest)} {nameof(vest.Quality)} is not equal.");

            Assert.That(brie.Name, Is.EqualTo("Aged Brie"), $"{nameof(brie)} {nameof(brie.Name)} is not equal.");
            Assert.That(brie.SellIn, Is.EqualTo(1), $"{nameof(brie)} {nameof(brie.SellIn)} is not equal.");
            Assert.That(brie.Quality, Is.EqualTo(1), $"{nameof(brie)} {nameof(brie.Quality)} is not equal.");

            Assert.That(elixir.Name, Is.EqualTo("Elixir of the Mongoose"), $"{nameof(elixir)} {nameof(elixir.Name)} is not equal.");
            Assert.That(elixir.SellIn, Is.EqualTo(4), $"{nameof(elixir)} {nameof(elixir.SellIn)} is not equal.");
            Assert.That(elixir.Quality, Is.EqualTo(6), $"{nameof(elixir)} {nameof(elixir.Quality)} is not equal.");

            Assert.That(sulfuras1.Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"), $"{nameof(sulfuras1)} {nameof(sulfuras1.Name)} is not equal.");
            Assert.That(sulfuras1.SellIn, Is.EqualTo(0), $"{nameof(sulfuras1)} {nameof(sulfuras1.SellIn)} is not equal.");
            Assert.That(sulfuras1.Quality, Is.EqualTo(80), $"{nameof(sulfuras1)} {nameof(sulfuras1.Quality)} is not equal.");

            Assert.That(sulfuras2.Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"), $"{nameof(sulfuras2)} {nameof(sulfuras2.Name)} is not equal.");
            Assert.That(sulfuras2.SellIn, Is.EqualTo(-1), $"{nameof(sulfuras2)} {nameof(sulfuras2.SellIn)} is not equal.");
            Assert.That(sulfuras2.Quality, Is.EqualTo(80), $"{nameof(sulfuras2)} {nameof(sulfuras2.Quality)} is not equal.");

            Assert.That(pass1.Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"), $"{nameof(pass1)} {nameof(pass1.Name)} is not equal.");
            Assert.That(pass1.SellIn, Is.EqualTo(14), $"{nameof(pass1)} {nameof(pass1.SellIn)} is not equal.");
            Assert.That(pass1.Quality, Is.EqualTo(21), $"{nameof(pass1)} {nameof(pass1.Quality)} is not equal.");

            Assert.That(pass2.Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"), $"{nameof(pass2)} {nameof(pass2.Name)} is not equal.");
            Assert.That(pass2.SellIn, Is.EqualTo(9), $"{nameof(pass2)} {nameof(pass2.SellIn)} is not equal.");
            Assert.That(pass2.Quality, Is.EqualTo(50), $"{nameof(pass2)} {nameof(pass2.Quality)} is not equal.");

            Assert.That(pass3.Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"), $"{nameof(pass3)} {nameof(pass3.Name)} is not equal.");
            Assert.That(pass3.SellIn, Is.EqualTo(4), $"{nameof(pass3)} {nameof(pass3.SellIn)} is not equal.");
            Assert.That(pass3.Quality, Is.EqualTo(50), $"{nameof(pass3)} {nameof(pass3.Quality)} is not equal.");

            Assert.That(cake.Name, Is.EqualTo("Conjured Mana Cake"), $"{nameof(cake)} {nameof(cake.Name)} is not equal.");
            Assert.That(cake.SellIn, Is.EqualTo(2), $"{nameof(cake)} {nameof(cake.SellIn)} is not equal.");
            Assert.That(cake.Quality, Is.EqualTo(4), $"{nameof(cake)} {nameof(cake.Quality)} is not equal.");
        });
    }
}
