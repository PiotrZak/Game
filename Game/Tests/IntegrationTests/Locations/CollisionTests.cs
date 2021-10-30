using System;
using System.Collections.Generic;
using Game.Engine;
using Game.Engine.Creatures;
using Xunit;

namespace Game.Tests
{
    public class CollisionTests
    {
        
        private readonly Player _player1 = new Player(1, 200, 220, 1, "Ziom1", 400, 5, 10);
 
        private readonly Player _player2 = new Player(1, 200, 167, 2, "Ziom2", 400, 5, 10);
        private Player _player3 = new Player(1, 200, 120, 3, "Ziom3", 400, 5, 10);
        private Player _player4 = new Player(1, 200, 145, 4, "Ziom4", 400, 5, 10);
        private List<Player> _crew = new List<Player>();
        private List<Spaceship> _spaceships = new List<Spaceship>();
        
        private Spaceship _a = new(Guid.NewGuid(), new Nation(), SpaceshipType.Chaser, 500, 50, 2400, 80, 10, 500);
        private Spaceship _b = new(Guid.NewGuid(), new Nation(), SpaceshipType.Chaser, 500, 50, 2400, 80, 10, 500);
        
        [Fact]
        public void MoveRightAndMeetAnAllyFleet()
        {
            
            
            _crew.AddRange(new List<Player>
            {
                _player2,
                _player3,
                _player4,
            });

            _spaceships.Add(_a);
            _spaceships.Add(_b);
            
            var fleet = new Fleet(1, new Nation(), _player1, _crew, Formation.Brigade, StrategyObjective.Navigator, _spaceships);
            var allyFleet = new Fleet(2, new Nation(), _player1, _crew, Formation.Brigade, StrategyObjective.Transport, _spaceships);
            var map = CosmosLocation.GenerateMap();

            map.Location[37].ActualFleetPosition = allyFleet;
            var actualFleetPosition = new LocationCoordinate(3, 8);
            var postulatedFleetPosition =  new LocationCoordinate(5, 8);

            var isCollision = CosmosMovement
                .CheckForCollision(map, fleet, actualFleetPosition, postulatedFleetPosition);

            Assert.True(isCollision);
        }

    }
}