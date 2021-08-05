using System.Collections.Generic;
using Game.Engine.Creatures.Abstraction;
using Game.Engine.Item;

namespace Game.Engine.Creatures
{
    public class Enemy : Creature
    {
        public Enemy(int id, string name, int health, int rewardExperiencePoints, int rewardGold, int currentHitPoints, int maximumHitPoints) : base(id, name, health, currentHitPoints, maximumHitPoints)
        {
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
        }

        private int RewardExperiencePoints { get; set; }
        private int RewardGold { get; set; }
        
        public List<LootItem> LootTable { get; set; }
        
    }
}