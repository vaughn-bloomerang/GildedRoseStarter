using System;

namespace GildedRoseKata
{
    public class BackstagePassesUpdate : IUpdate
    {
        public int UpdateQuality(int quality, int sellIn)
        {
            var newQuality = sellIn switch {
                <= 0 => 0,
                <= 5 => quality + 3,
                <= 10 => quality + 2,
                _ => quality + 1
            };

            return Math.Min(newQuality, 50);
        }
        
        public int UpdateSellIn(int sellIn)
        {
            return sellIn - 1;
        }
    }
}