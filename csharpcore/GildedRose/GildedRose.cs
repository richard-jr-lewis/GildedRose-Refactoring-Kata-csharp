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
            var isAgedBrie = item.Name == Names.AGED_BRIE;
            var isBackstagePasses = item.Name == Names.BACKSTAGE_PASSES;
            var isSulfuras = item.Name == Names.SULFURAS;

            var changeQualityBy = 0;

            if (isAgedBrie)
            {
                changeQualityBy++;

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    changeQualityBy++;
                }

                item.Quality = ChangeQuality(item.Quality, changeQualityBy);
            }
            else if (isBackstagePasses)
            {
                changeQualityBy++;

                if (item.SellIn < 11)
                {
                    changeQualityBy++;
                }

                if (item.SellIn < 6)
                {
                    changeQualityBy++;
                }

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    changeQualityBy = -item.Quality;
                }

                item.Quality = ChangeQuality(item.Quality, changeQualityBy);
            }
            else if (isSulfuras)
            {
            }
            else
            {
                changeQualityBy--;

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    changeQualityBy--;
                }

                item.Quality = ChangeQuality(item.Quality, changeQualityBy);
            }
        }
    }

    private static int ChangeQuality(int quality, int changeQualityBy) => Math.Clamp(quality + changeQualityBy, 0, 50);
}
