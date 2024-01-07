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
            if (item.Name != Names.AGED_BRIE && item.Name != Names.BACKSTAGE_PASSES)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != Names.SULFURAS)
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

                    if (item.Name == Names.BACKSTAGE_PASSES)
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

            if (item.Name != Names.SULFURAS)
            {
                item.SellIn--;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != Names.AGED_BRIE)
                {
                    if (item.Name != Names.BACKSTAGE_PASSES)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != Names.SULFURAS)
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