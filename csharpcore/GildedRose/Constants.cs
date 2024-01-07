namespace GildedRoseKata;

internal static class Names
{
    internal const string AGED_BRIE = "Aged Brie";
    internal const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
    internal const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    internal const string CONJURED = "Conjured";
}

internal static class Quality
{
    internal const int MIN= 0;
    internal const int MAX= 50;
    internal const int DEFAULT_CHANGE = -1;
    internal const int DEFAULT_EXPIRED_CHANGE = -2;
    internal const int AGED_BRIE_CHANGE = 1;
    internal const int AGED_BRIE_EXPIRED_CHANGE = 2;
    internal const int BACKSTAGE_PASSES_CHANGE = 1;
    internal const int BACKSTAGE_PASSES_FIRST_DEADLINE_CHANGE = 2;
    internal const int BACKSTAGE_PASSES_FINAL_DEADLINE_CHANGE = 3;
    internal const int CONJURED_CHANGE = DEFAULT_CHANGE * 2;
    internal const int CONJURED_EXPIRED_CHANGE = DEFAULT_EXPIRED_CHANGE * 2;
}

internal static class SellIn
{
    internal const int EXPIRY = 0;
    internal const int BACKSTAGE_PASSES_FIRST_DEADLINE = 10;
    internal const int BACKSTAGE_PASSES_FINAL_DEADLINE = 5;
}
