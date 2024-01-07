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

            int? changeQualityBy = null;

            if (isAgedBrie)
            {
                changeQualityBy = Quality.DEFAULT_INCREASE;

                item.SellIn--;

                if (item.SellIn < SellIn.EXPIRY)
                {
                    changeQualityBy++;
                }
            }
            else if (isBackstagePasses)
            {
                changeQualityBy = Quality.DEFAULT_INCREASE;

                if (item.SellIn < SellIn.BACKSTAGE_PASSES_FIRST_DEADLINE)
                {
                    changeQualityBy++;
                }

                if (item.SellIn < SellIn.BACKSTAGE_PASSES_FINAL_DEADLINE)
                {
                    changeQualityBy++;
                }

                item.SellIn--;

                if (item.SellIn < SellIn.EXPIRY)
                {
                    changeQualityBy = -item.Quality;
                }
            }
            else if (isSulfuras)
            {
            }
            else
            {
                changeQualityBy = Quality.DEFAULT_DECREASE;

                item.SellIn--;

                if (item.SellIn < SellIn.EXPIRY)
                {
                    changeQualityBy--;
                }
            }

            if (changeQualityBy.HasValue)
            {
                item.Quality = ChangeQuality(item.Quality, changeQualityBy.Value);
            }
        }
    }

    private static int ChangeQuality(int quality, int changeQualityBy) => Math.Clamp(quality + changeQualityBy, Quality.MIN, Quality.MAX);
}
