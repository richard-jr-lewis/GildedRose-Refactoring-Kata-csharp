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
                if (item.Quality < 50)
                {
                    item.Quality++;
                }

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
            }
            else if (isBackstagePasses)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;

                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
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
                if (item.Quality > 0)
                {
                    item.Quality--;
                }

                item.SellIn--;

                if (item.SellIn < 0)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                }
            }
        }
    }
}
