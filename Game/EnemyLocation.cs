using System;
using System.Collections.Generic;
using System.Linq;
using Game.Engine;
using Game.Engine.Creatures;
using Game.Engine.Item;

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
                
                var enemy  = new Enemy(
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
            }
            
            var weapons = 
                (from inventoryItem 
                    in _player.Inventory 
                    where inventoryItem.Details is Weapon 
                    where inventoryItem.Quantity > 0 
                    select (Weapon) inventoryItem.Details).ToList();
        }
    }
}