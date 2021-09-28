using System;

namespace GildedRoseKata.Updates
{
    public class NormalUpdate : IUpdate
    {
        public int UpdateQuality(int quality, int sellIn)
        {
            var qualityReduction = sellIn > 0 ? 1 : 2;
            return Math.Max(quality - qualityReduction, 0);
        }
        
        public int UpdateSellIn(int sellIn)
        {
            return sellIn - 1;
        }
    }
}