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
                changeQualityBy = Quality.AGED_BRIE_CHANGE;

                item.SellIn--;

                if (item.SellIn < SellIn.EXPIRY)
                {
                    changeQualityBy = Quality.AGED_BRIE_EXPIRED_CHANGE;
                }
            }
            else if (isBackstagePasses)
            {
                changeQualityBy = Quality.BACKSTAGE_PASSES_CHANGE;

                if (item.SellIn < SellIn.BACKSTAGE_PASSES_FIRST_DEADLINE)
                {
                    changeQualityBy = Quality.BACKSTAGE_PASSES_FIRST_DEADLINE_CHANGE;
                }

                if (item.SellIn < SellIn.BACKSTAGE_PASSES_FINAL_DEADLINE)
                {
                    changeQualityBy = Quality.BACKSTAGE_PASSES_FINAL_DEADLINE_CHANGE;
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
                changeQualityBy = Quality.DEFAULT_CHANGE;

                item.SellIn--;

                if (item.SellIn < SellIn.EXPIRY)
                {
                    changeQualityBy = -2;
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
