using System.Collections.Generic;
using GildedRoseKata.Updates;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        private static Dictionary<string, IUpdate> UpdateMap =>
            new() {
                { "Conjured Mana Cake", new ConjuredUpdate() },
                { "+5 Dexterity Vest", new NormalUpdate() },
                { "Elixir of the Mongoose", new NormalUpdate() },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassesUpdate() },
                { "Aged Brie", new AgedBrieUpdate() },
                { "Sulfuras, Hand of Ragnaros", new SulfurasUpdate() }
            };

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                item.Quality = UpdateMap[item.Name].UpdateQuality(item.Quality, item.SellIn);
                item.SellIn = UpdateMap[item.Name].UpdateSellIn(item.SellIn);
            }
        }
    }
}