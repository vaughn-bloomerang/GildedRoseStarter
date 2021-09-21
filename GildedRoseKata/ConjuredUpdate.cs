using System;

namespace GildedRoseKata
{
    public class ConjuredUpdate : IUpdate
    {
        public int UpdateQuality(int quality, int sellIn)
        {
            var qualityReduction = sellIn > 0 ? 2 : 4;
            return Math.Max(quality - qualityReduction, 0);
        }
        
        public int UpdateSellIn(int sellIn)
        {
            return sellIn - 1;
        }
    }
}