using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            bool isAgedBrie = item.Name == Names.AGED_BRIE;
            bool isBackstagePasses = item.Name == Names.BACKSTAGE_PASSES;
            bool isSulfuras = item.Name == Names.SULFURAS;

            if (isAgedBrie)
            {
                item.Quality = Math.Min(++item.Quality, 50);

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality = Math.Min(++item.Quality, 50);
                }
            }
            else if (isBackstagePasses)
            {
                item.Quality = Math.Min(++item.Quality, 50);

                if (item.SellIn < 11)
                {
                    item.Quality = Math.Min(++item.Quality, 50);
                }

                if (item.SellIn < 6)
                {
                    item.Quality = Math.Min(++item.Quality, 50);
                }

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
            }
            else if (isSulfuras)
            {
            }
            else
            {
                item.Quality = Math.Max(--item.Quality, 0);

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality = Math.Max(--item.Quality, 0);
                }
            }
        }
    }
}
