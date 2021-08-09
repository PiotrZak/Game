using Game.Engine.Creatures;
using Game.Engine.Item.Abstraction;
using Game.Engine.Quest;
using Xunit;

namespace Game.Tests.UnitTests
{
    public class HitsTests
    {
        private Enemy _enemy = new Enemy(1, "Alien", 500, 200, 150, 20, 40);
        // private ItemState _playerWeapon = new ItemState(new Item(1, "sword"), 1, 10, 10);
        //     
        // //var playerSpell = 
        // private Player _player = new Player(1, 200, 3, 3, "PlayerName", 400, 5, 10);
        //
        //
        // BattleLogic.HitToEnemy(50, 20)
        
        [Fact]
        public void AlienHealthAfter50HitIs450()
        {
            var enemy = BattleLogic.HitToEnemy(50, _enemy);
            Assert.Equal(450, enemy.Health);
        }
    
        [Fact]
        public void PlayerHealth40After20HitIs20()
        {
    
        }
        
    }
    
}