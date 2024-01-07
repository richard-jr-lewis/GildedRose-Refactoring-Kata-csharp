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
                changeQualityBy = item.SellIn > SellIn.EXPIRY ? Quality.AGED_BRIE_CHANGE : Quality.AGED_BRIE_EXPIRED_CHANGE;

                item.SellIn--;
            }
            else if (isBackstagePasses)
            {
                if (item.SellIn > SellIn.BACKSTAGE_PASSES_FIRST_DEADLINE)
                {
                    changeQualityBy = Quality.BACKSTAGE_PASSES_CHANGE;
                }
                else if (item.SellIn > SellIn.BACKSTAGE_PASSES_FINAL_DEADLINE)
                {
                    changeQualityBy = Quality.BACKSTAGE_PASSES_FIRST_DEADLINE_CHANGE;
                }
                else if (item.SellIn > SellIn.EXPIRY)
                {
                    changeQualityBy = Quality.BACKSTAGE_PASSES_FINAL_DEADLINE_CHANGE;
                }
                else
                {
                    changeQualityBy = -item.Quality;
                }

                item.SellIn--;
            }
            else if (isSulfuras)
            {
            }
            else
            {
                changeQualityBy = item.SellIn > SellIn.EXPIRY ? Quality.DEFAULT_CHANGE : Quality.DEFAULT_EXPIRED_CHANGE;

                item.SellIn--;
            }

            if (changeQualityBy.HasValue)
            {
                item.Quality = ChangeQuality(item.Quality, changeQualityBy.Value);
            }
        }
    }

    private static int ChangeQuality(int quality, int changeQualityBy) => Math.Clamp(quality + changeQualityBy, Quality.MIN, Quality.MAX);
}
