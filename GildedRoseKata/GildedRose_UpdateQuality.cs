using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Shouldly;
using Xunit;

namespace GildedRoseKata
{
    /// <summary>
    /// Test naming convention recommendation:
    /// https://ardalis.com/unit-test-naming-convention/
    /// </summary>
    public class GildedRose_UpdateQuality
    {
        [Fact]
        public void DoesNothingGivenSulfuras()
        {
            var initialQuality = 80;
            var items = new List<Item> {
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = initialQuality }
            };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var firstItem = items.First();

            // Use your preferred assertion library (already included - pick one delete others)
            // xunit default
            Assert.Equal(initialQuality, firstItem.Quality);

            // fluentassertions
            firstItem.Quality.Should().Be(initialQuality);

            // shouldly
            firstItem.Quality.ShouldBe(initialQuality);
        }
        
        [Fact]
        public void QualityDropsGivenConjured()
        {
            var initialQuality = 50;
            var items = new List<Item> {
                new() { Name = "Conjured Mana Cake", SellIn = 10, Quality = initialQuality }
            };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var firstItem = items.First();

            Assert.Equal(initialQuality - 2, firstItem.Quality);
        }
        
        [Fact]
        public void QualityDropsFasterGivenConjuredPastSellIn()
        {
            var initialQuality = 50;
            var items = new List<Item> {
                new() { Name = "Conjured Mana Cake", SellIn = -5, Quality = initialQuality }
            };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var firstItem = items.First();

            Assert.Equal(initialQuality - 4, firstItem.Quality);
        }
        
        [Fact]
        public void YayGivenConjured()
        {
            var initialQuality = 80;
            var items = new List<Item> {
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = initialQuality }
            };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var firstItem = items.First();

            // Use your preferred assertion library (already included - pick one delete others)
            // xunit default
            Assert.Equal(initialQuality, firstItem.Quality);

            // fluentassertions
            firstItem.Quality.Should().Be(initialQuality);

            // shouldly
            firstItem.Quality.ShouldBe(initialQuality);
        }
    }
}