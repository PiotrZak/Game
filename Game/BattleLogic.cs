#nullable enable
using System;
using Game.Engine;
using Game.Engine.Creatures;
using Game.Engine.Item;

namespace Game
{
    public class BattleLogic
    {

        private static Player _player;
        private readonly Enemy _currentEnemy;

        public BattleLogic(Player player, Enemy currentEnemy)
        {
            _player = player;
            _currentEnemy = currentEnemy;
        }

        public static void StartFight(Enemy enemy, Weapon playerWeapons, object? sender = null, EventArgs? e = null)
        {
            //todo - precise which weapon is seleected 
            var currentWeapon = playerWeapons;
            
            var random = new Random();
            var dmg = random.Next(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);
            
            enemy.CurrentHitPoints -= dmg;
            enemy.Health -= dmg;

            isEnemyDead(enemy);
        }

        private static void isEnemyDead(Enemy enemy)
        {
            if (enemy.Health <= 0)
            {
                Console.WriteLine("You defeated the" + enemy.Name);
                _player.ExperiencePoints += enemy.RewardExperiencePoints;
                _player.Gold += enemy.RewardGold;
            }
            else
            {
                var random = new Random();
                var dmg = random.Next(0, enemy.MaximumHitPoints);

                _player.Health -= dmg;

                if (_player.Health <= 0)
                {
                    Console.WriteLine("You are dead");
                    Location.MoveTo(World.LocationById(World.LocationBridge));
                }
            }
        }
    }
}