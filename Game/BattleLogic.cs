#nullable enable
using System;
using Game.Engine;
using Game.Engine.Creatures;
using Game.Engine.Item;
using Game.Engine.Quest;

namespace Game
{
    public class BattleLogic
    {
        private static Player _player;

        public BattleLogic(Player player)
        {
            _player = player;
        }

        public static void StartFight(Enemy enemy, ItemState playerWeapons, object? sender = null, EventArgs? e = null)
        {
            var currentWeapon = playerWeapons;
            
            var random = new Random();
            var dmg = random.Next((int) currentWeapon.MinimumDamage, (int) currentWeapon.MaximumDamage);
            
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

                
                //there is only Talisman and Key as defense items
                //to refactor
                var playerArmor = _player.Inventory
                    .Find(x => x.Details.Id == World.ItemIdTalisman 
                               || x.Details.Id == World.ItemIdKey);
                
                var defense = random.Next(
                    (int) playerArmor.MinimumDefense, 
                    (int) playerArmor.MaximumDefense
                    );

                _player.Health -= (dmg-defense);

                if (_player.Health <= 0)
                {
                    GameLoop.Restart();
                    Location.MoveTo(World.LocationById(World.LocationMachinery));
                }
            }
        }
    }
}