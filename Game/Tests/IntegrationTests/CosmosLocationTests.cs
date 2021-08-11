using Game.Engine;
using Xunit;

namespace Game.Tests
{
    public class CosmosLocationTests
    {
        // 10x10 matrix
        [Fact]
        public void MapHave100Points()
        {
            var map = CosmosLocation.GenerateMap();
            Assert.Equal(100, map.Location.Count);
        }
        
        [Fact]
        public void Point0Is1And1()
        {
            var map = CosmosLocation.GenerateMap();

            Assert.Equal(1, map.Location[0].X);
            Assert.Equal(1, map.Location[0].Y);
        }
        
        [Fact]
        public void Point9Is1And10()
        {
            var map = CosmosLocation.GenerateMap();

            Assert.Equal(1, map.Location[9].X);
            Assert.Equal(10, map.Location[9].Y);
        }
        
        [Fact]
        public void Point27Is3And8()
        {
            var map = CosmosLocation.GenerateMap();

            Assert.Equal(3, map.Location[27].X);
            Assert.Equal(8, map.Location[27].Y);
        }
        
        [Fact]
        public void Point53Is1And10()
        {
            var map = CosmosLocation.GenerateMap();

            Assert.Equal(6, map.Location[53].X);
            Assert.Equal(4, map.Location[53].Y);
        }
        
        [Fact]
        public void Point72Is3And8()
        {
            var map = CosmosLocation.GenerateMap();

            Assert.Equal(8, map.Location[72].X);
            Assert.Equal(3, map.Location[72].Y);
        }
        
        [Fact]
        public void Point99Is10And10()
        {
            var map = CosmosLocation.GenerateMap();

            Assert.Equal(10, map.Location[99].X);
            Assert.Equal(10, map.Location[99].Y);
        }
    }
}