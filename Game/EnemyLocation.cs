using System;
using System.Collections.Generic;
using System.Linq;
using Game.Engine;
using Game.Engine.Creatures;
using Game.Engine.Item;
using Game.Engine.Quest;

namespace Game
{
    public class EnemyLocation
    {
        private static Player _player;

        public static void CheckForEnemy(Location newLocation)
        {
            if (newLocation.EnemyLivingHere != null)
            {
                Console.WriteLine("There is: " + newLocation.EnemyLivingHere.Name);

                var enemyHere = World.EnemyById(newLocation.EnemyLivingHere.Id);
                
                var enemy = new Enemy(
                    enemyHere.Id,
                    enemyHere.Name,
                    enemyHere.Health,
                    enemyHere.RewardExperiencePoints,
                    enemyHere.RewardGold,
                    enemyHere.CurrentHitPoints,
                    enemyHere.MaximumHitPoints
                );
                foreach(var lootItem in enemyHere.LootTable)
                {
                    enemyHere.LootTable.Add(lootItem);
                }

                var playerWeapons = new List<ItemState>();
                foreach (var inventoryItem in _player.Inventory)
                {
                    //todo - get selected weapon or get the strongest one
                    if (inventoryItem.MaximumDamage != null && inventoryItem.MinimumDamage != null)
                    {
                        if (inventoryItem.Quantity > 0) playerWeapons.Add(inventoryItem);
                    }
                }

                //todo - what if player have more than 2 weapon - also distance and manual weapon
                BattleLogic.StartFight(enemy, playerWeapons[0]);
            }
        }
    }
}