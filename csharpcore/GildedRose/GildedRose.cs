﻿using System.Collections.Generic;

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

            if (!isAgedBrie && !isBackstagePasses)
            {
                if (item.Quality > 0)
                {
                    if (!isSulfuras)
                    {
                        item.Quality--;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality++;

                    if (isBackstagePasses)
                    {
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
                }
            }

            if (!isSulfuras)
            {
                item.SellIn--;
            }

            if (item.SellIn < 0)
            {
                if (!isAgedBrie)
                {
                    if (!isBackstagePasses)
                    {
                        if (item.Quality > 0)
                        {
                            if (!isSulfuras)
                            {
                                item.Quality--;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
            }
        }
    }
}