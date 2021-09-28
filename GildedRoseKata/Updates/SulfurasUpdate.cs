namespace GildedRoseKata.Updates
{
    public class SulfurasUpdate : IUpdate
    {
        public int UpdateQuality(int quality, int sellIn)
        {
            return quality;
        }
        
        public int UpdateSellIn(int sellIn)
        {
            return sellIn;
        }
    }
}