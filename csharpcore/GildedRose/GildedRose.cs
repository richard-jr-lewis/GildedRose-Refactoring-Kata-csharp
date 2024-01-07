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
                item.Quality = ChangeQuality(item.Quality, 1);

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality = ChangeQuality(item.Quality, 1);
                }
            }
            else if (isBackstagePasses)
            {
                item.Quality = ChangeQuality(item.Quality, 1);

                if (item.SellIn < 11)
                {
                    item.Quality = ChangeQuality(item.Quality, 1);
                }

                if (item.SellIn < 6)
                {
                    item.Quality = ChangeQuality(item.Quality, 1);
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
                item.Quality = ChangeQuality(item.Quality, -1);

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality = ChangeQuality(item.Quality, -1);
                }
            }
        }
    }

    private static int ChangeQuality(int quality, int changeBy) => Math.Clamp(quality + changeBy, 0, 50);
}
