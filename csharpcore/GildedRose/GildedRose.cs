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
                item.Quality = IncreaseQuality(item.Quality);

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality = IncreaseQuality(item.Quality);
                }
            }
            else if (isBackstagePasses)
            {
                item.Quality = IncreaseQuality(item.Quality);

                if (item.SellIn < 11)
                {
                    item.Quality = IncreaseQuality(item.Quality);
                }

                if (item.SellIn < 6)
                {
                    item.Quality = IncreaseQuality(item.Quality);
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
                item.Quality = DecreaseQuality(item.Quality);

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality = DecreaseQuality(item.Quality);
                }
            }
        }
    }

    private static int IncreaseQuality(int quality) => Math.Min(++quality, 50);

    private static int DecreaseQuality(int quality) => Math.Max(--quality, 0);
}
