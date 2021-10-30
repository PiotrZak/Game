using System;
using Game.Engine.Creatures;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace Game.Tests
{
    public class BattleLogicTests
    {
        // private Spaceship _a = new Spaceship();
        // private Spaceship _b = new Spaceship();
        
        private readonly Enemy _enemy = new Enemy(1, "Alien", 500, 200, 150, 20, 40);
        private readonly Enemy _weakerEnemy = new Enemy(1, "Zombie", 350, 200, 90, 2, 4);
        private readonly Player _player = new Player(1, 200, 3, 3, "PlayerName", 400, 5, 10);
        
        
        // [Fact]
        // public void SpaceshipADestroySpaceshipB()
        // {
        //     var isDead = SpaceshipsBattle.StartBattle(_a, _b);
        //     Assert.False(isDead);
        // }
        //
        // [Fact]
        // public void SpaceshipBDestroySpaceshipA()
        // {
        //     var isDead = SpaceshipsBattle.StartBattle(_a, _b);
        //     Assert.False(isDead);
        // }
        
        [Fact]
        public void PlayerWillLoseWithEnemy()
        {
            var ex = Assert.Throws<ArgumentException>(() => BattleLogic.StartFight(_enemy, _player));
            Assert.Equal("Game not loaded!", ex.Message);
        }
    
        [Fact]
        public void PlayerWillWinWithEnemyAndGetLoot()
        {
            var isDead = BattleLogic.StartFight(_weakerEnemy, _player);

            Assert.Equal(400, _player.ExperiencePoints);
            Assert.Equal(91, _player.Gold);
            Assert.True(isDead);
        }
    }
}