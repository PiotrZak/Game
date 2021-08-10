#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Game.Engine;
using Game.Engine.Creatures;
using Game.Engine.Quest;

namespace Game
{
    public class BattleLogic
    {
        public static bool StartFight(Enemy enemy, Player player)
        {
            
            var playerWeapons = new List<ItemState>();
            foreach (var inventoryItem in player.Inventory)
            {
                //todo - get selected weapon or get the strongest one
                if (inventoryItem.MaximumDamage != null && inventoryItem.MinimumDamage != null)
                {
                    if (inventoryItem.Quantity > 0) playerWeapons.Add(inventoryItem);
                }
            }

            var random = new Random();

            var playerDmg = playerWeapons.Any() 
                ? random.Next((int) playerWeapons[0].MinimumDamage, (int) playerWeapons[0].MaximumDamage) 
                : random.Next(player.CurrentHitPoints, player.MaximumHitPoints);
      
            var enemyDmg = random.Next((int) enemy.CurrentHitPoints, (int) enemy.MaximumHitPoints);

            while (!(enemy.Health <= 0) && !(player.Health <= 0))
            {
                HitToEnemy(playerDmg, enemy);
                HitToPlayer(enemyDmg, player);
            }

            if (enemy.Health <= 0)
            {
                Console.WriteLine("You defeated the" + enemy.Name);
                player.ExperiencePoints += enemy.RewardExperiencePoints;
                player.Gold += enemy.RewardGold;
                return true;
            }
            if (player.Health <= 0)
            {
                GameLoop.Restart();
                return false;
            }

            return true;
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
            var playerArmor = creature.Inventory
                .Find(x => x.Details.Id == World.ItemIdTalisman 
                           || x.Details.Id == World.ItemIdKey);
            var random = new Random();

            var defense = 0;
            if (playerArmor != null)
            {
                defense = random.Next(
                    (int) playerArmor.MinimumDefense,
                    (int) playerArmor.MaximumDefense
                );
            }

            creature.Health -= (dmg-defense);

            return creature;
        }
    }
}