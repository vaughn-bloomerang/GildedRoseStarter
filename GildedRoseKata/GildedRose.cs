using System.Collections.Generic;

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
                if (UpdateMap.ContainsKey(item.Name))
                {
                    item.Quality = UpdateMap[item.Name].UpdateQuality(item.Quality, item.SellIn);
                    item.SellIn = UpdateMap[item.Name].UpdateSellIn(item.SellIn);
                    continue;
                }

                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}