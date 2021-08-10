using Game.Engine.Creatures;
using Xunit;

namespace Game.Tests.UnitTests
{
    public class HitsTests
    {
        private Enemy _enemy = new Enemy(1, "Alien", 500, 200, 150, 20, 40);
        private Player _player = new Player(1, 200, 3, 3, "PlayerName", 400, 5, 10);
        
        [Fact]
        public void AlienHealthAfter50HitIs450()
        {
            var enemy = BattleLogic.HitToEnemy(50, _enemy);
            Assert.Equal(450, enemy.Health);
        }

        //todo defense test
        
    }
    
}