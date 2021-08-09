#nullable enable
using System;
using System.Collections.Generic;
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

        public static void StartFight(Enemy enemy, object? sender = null, EventArgs? e = null)
        {
            
            var playerWeapons = new List<ItemState>();
            foreach (var inventoryItem in _player.Inventory)
            {
                //todo - get selected weapon or get the strongest one
                if (inventoryItem.MaximumDamage != null && inventoryItem.MinimumDamage != null)
                {
                    if (inventoryItem.Quantity > 0) playerWeapons.Add(inventoryItem);
                }
            }

            var random = new Random();
            var playerDmg = random.Next((int) playerWeapons[0].MinimumDamage, (int) playerWeapons[0].MaximumDamage);
            var enemyDmg = random.Next((int) enemy.CurrentHitPoints, (int) enemy.MaximumHitPoints);

            while (enemy.Health <= 0 || _player.Health <= 0)
            {
                HitToEnemy(playerDmg, enemy);
                HitToPlayer(enemyDmg, _player);
            }

            if (enemy.Health <= 0)
            {
                Console.WriteLine("You defeated the" + enemy.Name);
                _player.ExperiencePoints += enemy.RewardExperiencePoints;
                _player.Gold += enemy.RewardGold;
            }
            if (_player.Health <= 0)
            {
                GameLoop.Restart();
            }
        }
        
        public static Enemy HitToEnemy(int dmg, Enemy creature)
        {
            creature.CurrentHitPoints -= dmg;
            creature.Health -= dmg;
            return creature;
        }
        
        public static Player HitToPlayer(int dmg, Player creature)
        {
            creature.CurrentHitPoints -= dmg;
            creature.Health -= dmg;
            var playerArmor = _player.Inventory
                .Find(x => x.Details.Id == World.ItemIdTalisman 
                           || x.Details.Id == World.ItemIdKey);
            var random = new Random();
            var defense = random.Next(
                (int) playerArmor.MinimumDefense, 
                (int) playerArmor.MaximumDefense
            );

            _player.Health -= (dmg-defense);

            return _player;
        }
    }
}