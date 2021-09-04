using System.Collections.Generic;
using Game.Engine;
using Xunit;

namespace Game.Tests
{
    
    public class SpaceshipsFactory
    {
        private readonly List<int> _chaserCost = new List<int>() {4000, 2000, 1000};
        private readonly List<int> _shuttleCost = new List<int>() {8000, 4000, 1800};
        private readonly List<int> _destroyerCost = new List<int>() {18000, 12000, 4000};
        
        [Fact]
        public void IsMaterialsEnough()
        {
            var availableSteel = 12000;
            var availableAluminium = 4000;
            var availableRocketPopulsion = 4000;
            
            var actualState = new[] {availableSteel, availableAluminium, availableRocketPopulsion};

            var nationCanBuildChaser =
                Engine.SpaceshipsFactory.IsDemandFullfill(_chaserCost, actualState);
            
            var nationCanBuildCShuttle =
                Engine.SpaceshipsFactory.IsDemandFullfill(_shuttleCost, actualState);
            
            var nationCanBuildDestroyer =
                Engine.SpaceshipsFactory.IsDemandFullfill(_destroyerCost, actualState);
            
            Assert.True(nationCanBuildChaser);
            Assert.True(nationCanBuildCShuttle);
            Assert.False(nationCanBuildDestroyer);

        }
        
        [Fact]
        public void ThereIsOptionFor3Chasers()
        {
            const int availableSteel = 12000;
            const int availableAluminium = 6000;
            const int availableRocketPopulsion = 4000;

            var actualState = new[] {availableSteel, availableAluminium, availableRocketPopulsion};

            var quantityChasers =
                Engine.SpaceshipsFactory.CalculatePossibleQuantityBuild(_chaserCost, actualState);

            Assert.Equal(3, quantityChasers);
        }
        
        [Fact]
        public void ThereIsOptionFor1Shuttle()
        {
            var quantity = 5;

            const int availableSteel = 12000;
            const int availableAluminium = 6000;
            const int availableRocketPopulsion = 4000;
            
            var actualState = new[] {availableSteel, availableAluminium, availableRocketPopulsion};
            var quantityShuttle =
                Engine.SpaceshipsFactory.CalculatePossibleQuantityBuild(_shuttleCost, actualState);

            Assert.Equal(1, quantityShuttle);
        }
        
        [Fact]
        public void ThereIsOptionFor0Destroyers()
        {
            const int availableSteel = 12000;
            const int availableAluminium = 6000;
            const int availableRocketPopulsion = 4000;

            var actualState = new[] {availableSteel, availableAluminium, availableRocketPopulsion};
            
            var quantityDestroyers =
                Engine.SpaceshipsFactory.CalculatePossibleQuantityBuild(_destroyerCost, actualState);
            
            Assert.Equal(0, quantityDestroyers);
        }
        
        [Fact]
        public void BuildSpaceship()
        {
            var nation = new Nation();
            var spaceships = new List<Spaceship>();

            var test = Engine.SpaceshipsFactory.BuildSpaceship(nation, SpaceshipType.Chaser, 5);
                
            Assert.Equal(spaceships, test);
        }
        
        [Fact]
        public void ThereIs2000LackOfSteelAnd1000ofAluminium()
        {
            const int availableSteel = 2000;
            const int availableAluminium = 1000;
            const int availableRocketPopulsion = 4000;

            var actualState = new[] {availableSteel, availableAluminium, availableRocketPopulsion};

            var quantityChasers =
                Engine.SpaceshipsFactory.CalculateLackOfDemands(_chaserCost, actualState);

            Assert.Equal(2000, quantityChasers[0]);
            Assert.Equal(1000, quantityChasers[1]);
        }
        
        [Fact]
        public void ThereIs2200LackOfSteelAnd1200ofAluminiumAnd930Populsion()
        {
            const int availableSteel = 1800;
            const int availableAluminium = 800;
            const int availableRocketPopulsion = 70;

            var actualState = new[] {availableSteel, availableAluminium, availableRocketPopulsion};

            var quantityChasers =
                Engine.SpaceshipsFactory.CalculateLackOfDemands(_chaserCost, actualState);

            Assert.Equal(2200, quantityChasers[0]);
            Assert.Equal(1200, quantityChasers[1]);
            Assert.Equal(930, quantityChasers[2]);
        }
        
        
    }
}