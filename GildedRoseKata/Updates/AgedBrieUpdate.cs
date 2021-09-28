using System;

namespace GildedRoseKata.Updates
{
    public class AgedBrieUpdate : IUpdate
    {
        public int UpdateQuality(int quality, int sellIn)
        {
            var qualityAddition = sellIn <= 0 ? 2 : 1;
            return Math.Min(quality + qualityAddition, 50);
        }
        
        public int UpdateSellIn(int sellIn)
        {
            return sellIn - 1;
        }
    }
}